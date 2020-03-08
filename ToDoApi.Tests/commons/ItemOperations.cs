using System.Collections.Generic;

class ItemOperations
{
        public static void DeleteAllItems() {
            List<TodoResponseItem> todosList = TodoClients.GetAllTodos();
            todosList.ForEach ( x =>
                TodoClients.DeleteTodoId(x.id)
            );
        }

        public static bool todoContains(string name, bool isComplete, List<TodoResponseItem> todoList)
        {
            bool result = false;
            todoList.ForEach(x =>
                {
                    result = (x.name == name && x.isComplete == isComplete) ? true : result;
                }
            );
            return result;
        }
}