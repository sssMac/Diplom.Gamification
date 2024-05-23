using Microsoft.AspNetCore.Mvc;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Diplom.Gamification.Application.ViewModels;
using Diplom.Gamification.Application.Extensions;


namespace Diplom.Gamification.Web.Controllers
{
	public class ShortsController : Controller
	{
		public async Task<IActionResult> Index()
		{
			Console.WriteLine("YouTube Data API: Search");
			Console.WriteLine("========================");
			var videos = new List<ShortsViewModel>();
			try
			{
                videos = await Run();
			}
			catch (AggregateException ex)
			{
				foreach (var e in ex.InnerExceptions)
				{
					Console.WriteLine("Error: " + e.Message);
				}
			}

			return View(videos);
		}

		private async Task<List<ShortsViewModel>> Run()
		{
			var youtubeService = new YouTubeService(new BaseClientService.Initializer()
			{
				ApiKey = "AIzaSyCC2uux1RPyEJBxAWkRzYSflDUxI6BD0XE",
				ApplicationName = this.GetType().ToString()
			});

			var searchListRequest = youtubeService.Search.List("snippet");
			searchListRequest.Q = "програмирование shorts";
			searchListRequest.MaxResults = 250;

            var searchListResponse = await searchListRequest.ExecuteAsync();

			List<ShortsViewModel> videos = new List<ShortsViewModel>();

			foreach (var searchResult in searchListResponse.Items)
			{
				switch (searchResult.Id.Kind)
				{
					case "youtube#video":
						if (searchResult.Snippet.Title.ToLower().Contains("#shorts") && searchResult.Snippet.Title.ToLower().Contains("#програм"))
						{
                            videos.Add(new ShortsViewModel { Title = searchResult.Snippet.Title, VideoId = searchResult.Id.VideoId });
                            await Console.Out.WriteLineAsync(searchResult.Id.VideoId);
                        }
                        break;
				}
			}
			videos.Shuffle();

            return videos;
        }

        

    }
}
