using System;
using Xunit;
using RestSharp;
using System.Collections.Generic;

namespace todoapi.Tests
{
    public class TodoListTest
    {
        public TodoListTest()
        {
            ItemOperations.DeleteAllItems();
        }

        [Fact]
        public void TestAddNewTodoItem()
        {
            // given
            var newItem = new TodoRequest("yoga", false);
            // when
            TodoClients.PostNewTodoItem(newItem);
            // then
            List<TodoResponseItem> resultList = TodoClients.GetAllTodos();
            Assert.True(ItemOperations.todoContains(newItem.Name, newItem.IsComplete, resultList)); 
        }


    }
}
