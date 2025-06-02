namespace MyAvaloniaApp.Domains.Todo

open Elmish

module State =
    let init () = { Items = [ "Buy milk" ] }, Cmd.none  // Add a sample item

    let update msg model =
        match msg with
        | Add item -> { model with Items = item :: model.Items }, Cmd.none
        | Remove idx -> 
            let newItems = model.Items |> List.mapi (fun i x -> i, x) |> List.filter (fun (i, _) -> i <> idx) |> List.map snd
            { model with Items = newItems }, Cmd.none