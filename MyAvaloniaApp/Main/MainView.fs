namespace MyAvaloniaApp.Main

open Avalonia.FuncUI.DSL
open Avalonia.Controls
open MyAvaloniaApp.Domains

module View =
    let view model dispatch =
        StackPanel.create [
            StackPanel.children [
                Counter.View.view model.Counter (Msg.CounterMsg >> dispatch)
                Todo.View.view model.Todo (Msg.TodoMsg >> dispatch)
            ]
        ]