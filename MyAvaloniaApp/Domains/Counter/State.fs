namespace MyAvaloniaApp.Domains.Counter

open Elmish

module State =
    let init () = { Count = 0 }, Cmd.none

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }, Cmd.none
        | Decrement -> { model with Count = model.Count - 1 }, Cmd.none