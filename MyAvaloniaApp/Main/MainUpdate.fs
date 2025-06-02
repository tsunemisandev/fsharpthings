namespace MyAvaloniaApp.Main

open Elmish
open MyAvaloniaApp.Domains
open MyAvaloniaApp.Domains.Counter
open MyAvaloniaApp.Domains.Todo

module Update =
    let init () =
        let counterModel, counterCmd = Counter.State.init ()
        let todoModel, todoCmd = Todo.State.init ()
        { Counter = counterModel; Todo = todoModel },
        Cmd.batch [
            Cmd.map Msg.CounterMsg counterCmd
            Cmd.map Msg.TodoMsg todoCmd
        ]

    let update msg model =
        match msg with
        | Msg.CounterMsg cm ->
            let newCounter, cmd = Counter.State.update cm model.Counter
            { model with Counter = newCounter }, Cmd.map Msg.CounterMsg cmd
        | Msg.TodoMsg tm ->
            let newTodo, cmd = Todo.State.update tm model.Todo
            { model with Todo = newTodo }, Cmd.map Msg.TodoMsg cmd