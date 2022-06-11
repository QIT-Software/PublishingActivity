using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PublishingActivity.BLL.Interfaces;
using PublishingActivity.WEB.Infrastructure.Automapper;
using PublishingActivity.WEB.Models;
using PublishingActivity.WEB.Models.PublicationVM;

namespace PublishingActivity.WEB.Controllers
{
    public class PublicationController : Controller
    {
        private readonly IPublicationService _publicationService;
        public PublicationController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }
        // GET: Publication
        [Authorize]
        public ActionResult Publications()
        {
            var publications = new IndexViewModel<PublicationViewModel>
            {
                Items = _publicationService.GetAllPublication(User.Identity.GetUserId()).ToDisplayVM(),
                Model = new PublicationViewModel()
            };
            return View(publications);
        }

        [HttpGet]
        public ActionResult ParsePublication(string textInput)
        {
            var publication = new PublicationEditModel();

            if (!string.IsNullOrWhiteSpace(textInput) && !string.IsNullOrEmpty(textInput))
            {
                Regex regexPages = new Regex("\\s[А-я, A-z].\\s\\d");
                var checkIfPagesExist = regexPages.Match(textInput);
                var pagesResult = checkIfPagesExist.Groups[0].ToString();

                Regex regexYear = new Regex("[0-9]{4}");
                var checkIfYearExists = regexYear.Match(textInput);
                var yearResult = checkIfYearExists.Groups[0].ToString();

                publication.Year = yearResult != string.Empty ? Convert.ToInt32(yearResult) : 0;

                publication.ProfessorName = textInput.Substring(0, textInput.IndexOf(',')).TrimStart();
                textInput = textInput.Replace(publication.ProfessorName + ",", "");

                publication.Subject = textInput.Substring(0, textInput.IndexOf('/')).TrimStart();
                textInput = textInput.Replace(publication.Subject + "/", "");

                publication.CoAuthors = textInput.Substring(0, textInput.IndexOf('/')).TrimStart();
                textInput = textInput.Replace(publication.CoAuthors + "//", "");

                if (textInput.IndexOf(pagesResult, StringComparison.Ordinal) != -1)
                {
                    publication.Pages = textInput.Substring(textInput.IndexOf(pagesResult, StringComparison.Ordinal) + 1).TrimStart();

                    textInput = textInput.Replace(publication.Pages, "");
                    textInput = textInput.Remove(textInput.LastIndexOf(".", StringComparison.Ordinal));
                    publication.LocationAndDate = textInput.TrimStart();
                }
                else
                    publication.LocationAndDate = textInput;

                publication.ProfessorName = publication.ProfessorName.Trim();
                publication.Subject = publication.Subject.Trim();
                publication.CoAuthors = publication.CoAuthors.Trim();
                publication.LocationAndDate = publication.LocationAndDate.Trim();
                publication.Pages = publication.Pages.Trim();
                publication.Pages = publication.Pages.Remove(publication.Pages.LastIndexOf(".", StringComparison.Ordinal));
            }

            return Json(publication, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult AddPublication()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPublication(PublicationEditModel model)
        {
            if (ModelState.IsValid)
            {
                _publicationService.AddPublication(model.ToDTO(), User.Identity.GetUserId());
                return RedirectToAction("Publications", "Publication");
            }
            return View(model);
        }
        [Authorize]
        public ActionResult EditPublication(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(_publicationService.GetPublicationById(id.GetValueOrDefault()).ToEditVM());
        }
        [HttpPost]
        public ActionResult EditPublication(PublicationEditModel model)
        {
            if (ModelState.IsValid)
            {
                _publicationService.EditPublication(model.ToDTO());
                return RedirectToAction("Publications", "Publication");
            }
            return View(model);
        }
        [Authorize]
        public ActionResult DeletePublication(int? id)
        {
            if (id == null)
                return HttpNotFound();
            _publicationService.SoftDeletePublication(id.GetValueOrDefault());

            return RedirectToAction("Publications", "Publication");
        }
        [Authorize]
        public ActionResult PublicationGraph()
        {
            return View(new GraphVM(){Items = _publicationService.AllPublicationsByYears(User.Identity.GetUserId()) });
        }
        [Authorize]
        public FileResult GetCSV()
        {
            var stream = _publicationService.ToCSV(User.Identity.GetUserId());

            return File(stream, System.Net.Mime.MediaTypeNames.Application.Octet, "Publications.csv");
        }
    }
}