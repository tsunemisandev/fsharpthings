namespace MyAvaloniaApp.Domains.Counter

open Avalonia.FuncUI.DSL
open Avalonia.Controls

module View =
    let view model dispatch =
        StackPanel.create [
            StackPanel.children [
                Button.create [ Button.content "+"; Button.onClick (fun _ -> dispatch Increment) ]
                TextBlock.create [ TextBlock.text (string model.Count) ]
                Button.create [ Button.content "-"; Button.onClick (fun _ -> dispatch Decrement) ]
            ]
        ]