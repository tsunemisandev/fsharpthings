namespace MyAvaloniaApp.Domains.Todo

open Avalonia.FuncUI.DSL
open Avalonia.Controls
open Avalonia.Layout

module View =
    let view model dispatch =
        StackPanel.create [
            StackPanel.children (
                model.Items
                |> List.mapi (fun i item ->
                    StackPanel.create [
                        StackPanel.orientation Orientation.Horizontal
                        StackPanel.children [
                            TextBlock.create [ TextBlock.text item ]
                            Button.create [ Button.content "X"; Button.onClick (fun _ -> dispatch (Remove i)) ]
                        ]
                    ])
            )
        ]