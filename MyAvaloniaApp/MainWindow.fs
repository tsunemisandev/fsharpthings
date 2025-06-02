namespace MyAvaloniaApp

open Elmish
open Avalonia.FuncUI.Elmish
open Avalonia.FuncUI.Hosts
open MyAvaloniaApp.Main

type MainWindow() as this =
    inherit HostWindow()
    do
        base.Title <- "Multi-Domain Elmish App"
        base.Width <- 600.0
        base.Height <- 400.0
        Program.mkProgram Update.init Update.update View.view
        |> Program.withHost this
        |> Program.run