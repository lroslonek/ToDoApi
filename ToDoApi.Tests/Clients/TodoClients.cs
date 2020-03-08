using RestSharp;
using Xunit;
using Newtonsoft.Json;
using System; 
using System.Collections.Generic;

class TodoClients
{
    public const string AppUri = "http://localhost:5000";

    public static void PostNewTodoItem(TodoRequest payload) 
    {
        var request = new RestRequest("/api/todo").AddJsonBody(payload);
        var response = new RestClient(AppUri).Post(request);
        Assert.Equal(201, (int)response.StatusCode);
    }   

    public static List<TodoResponseItem> GetAllTodos()
    {
        var request = new RestRequest("/api/todo");
        var response = new RestClient(AppUri).Get(request);
        Assert.Equal(200, (int)response.StatusCode);
        
        List<TodoResponseItem> todoList = JsonConvert
            .DeserializeObject<List<TodoResponseItem>>(response.Content);

        return todoList;
    }

    public static TodoResponseItem GetTodoId(int id)
    {
        var request = new RestRequest($"/api/todo/{id}");
        var response = new RestClient(AppUri).Get(request);
        Assert.Equal(200, (int)response.StatusCode);
        
        TodoResponseItem todoItem = JsonConvert
            .DeserializeObject<TodoResponseItem>(response.Content);
            
        return todoItem;
    }

    public static void DeleteTodoId(int id)
    {
        var request = new RestRequest($"/api/todo/{id}");
        var response = new RestClient(AppUri).Delete(request);
        Assert.Equal(200, (int)response.StatusCode);
    }
    
}