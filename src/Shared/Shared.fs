namespace safetest.Shared

open System

type Todo =
    { Id : Guid
      Description : string }

module Todo =
    let isValid (description: string) =
        String.IsNullOrWhiteSpace description |> not

    let create (description: string) =
        { Id = Guid.NewGuid()
          Description = description }

module Route =
    /// Defines how routes are generated on server and mapped from client
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type ITodosApi =
    { getTodos : Async<Todo list>
      addTodo : Todo -> Async<Todo> }
