using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using PodcastMonitor.Web.Api.Models.Feed;
using PodcastMonitor.Web.Frontend.Filters;
using PodcastMonitor.Web.Frontend.Models;
using RestSharp;
using RestSharp.Deserializers;

namespace PodcastMonitor.Web.Frontend.Controllers
{
    [System.Web.Http.Authorize]
    public class FeedListController : Controller
    {
        public ViewResult Feeds(FeedListViewModel viewModel)
        {
            var client = new RestClient("http://localhost:52668/api");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("feeds", Method.GET);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", id.ToString()); // replaces matching token in request.Resource

            request.AddHeader("header", "value");

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();


            client.AddHandler( "application/json", new JsonDeserializer());
            var response2 = client.Execute<FeedListViewModel>(request);
            viewModel = response2.Data;

            // easy async support
            //client.ExecuteAsync(request, resp => Console.WriteLine(response.Content));

            // async with deserialization
            //var asyncHandle = client.ExecuteAsync<FeedViewModel>(request, resp => Console.WriteLine(resp.Data.Name));

            // abort the request on demand
            //asyncHandle.Abort();

            return View(viewModel);
        }
    }

    [System.Web.Http.Authorize]
    public class TodoListController : ApiController
    {
        private TodoItemContext db = new TodoItemContext();

        // GET api/TodoList
        public IEnumerable<TodoListDto> GetTodoLists()
        {
            return db.TodoLists.Include("Todos")
                .Where(u => u.UserId == User.Identity.Name)
                .OrderByDescending(u => u.TodoListId)
                .AsEnumerable()
                .Select(todoList => new TodoListDto(todoList));
        }

        // GET api/TodoList/5
        public TodoListDto GetTodoList(int id)
        {
            TodoList todoList = db.TodoLists.Find(id);
            if (todoList == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            if (todoList.UserId != User.Identity.Name)
            {
                // Trying to modify a record that does not belong to the user
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Unauthorized));
            }

            return new TodoListDto(todoList);
        }

        // PUT api/TodoList/5
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage PutTodoList(int id, TodoListDto todoListDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != todoListDto.TodoListId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            TodoList todoList = todoListDto.ToEntity();
            if (db.Entry(todoList).Entity.UserId != User.Identity.Name)
            {
                // Trying to modify a record that does not belong to the user
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            db.Entry(todoList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/TodoList
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage PostTodoList(TodoListDto todoListDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            todoListDto.UserId = User.Identity.Name;
            TodoList todoList = todoListDto.ToEntity();
            db.TodoLists.Add(todoList);
            db.SaveChanges();
            todoListDto.TodoListId = todoList.TodoListId;

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, todoListDto);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = todoListDto.TodoListId }));
            return response;
        }

        // DELETE api/TodoList/5
        [ValidateHttpAntiForgeryToken]
        public HttpResponseMessage DeleteTodoList(int id)
        {
            TodoList todoList = db.TodoLists.Find(id);
            if (todoList == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (db.Entry(todoList).Entity.UserId != User.Identity.Name)
            {
                // Trying to delete a record that does not belong to the user
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            TodoListDto todoListDto = new TodoListDto(todoList);
            db.TodoLists.Remove(todoList);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.OK, todoListDto);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}