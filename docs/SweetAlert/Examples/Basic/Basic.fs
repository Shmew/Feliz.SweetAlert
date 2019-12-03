[<RequireQualifiedAccess>]
module Samples.Basic

open Elmish
open Feliz
open Feliz.ElmishComponents
open Feliz.SweetAlert

type Model = { Test: string }

let init () = { Test = "" }, Cmd.none

type Msg =
    | SendAlert
    | GotMsg of string option

let dispatchTest (elem: ReactElement) =
    Swal.fire [
        swal.title "test"
        swal.html elem
        swal.icon.success
    ]

let reactTest = React.functionComponent (fun () ->
    Html.div [
        prop.text "Howdy!"
    ])

let update msg model =
    match msg with
    | SendAlert ->
        let handleConfirm (result: SweetAlertResult<string>) =
            match result with
            | ResultValue s -> Msg.GotMsg (Some s)
            | _ -> Msg.GotMsg None

        model, Cmd.Swal.fire([ swal.title "test"; swal.html (reactTest()); swal.icon.success ], handleConfirm)
    | GotMsg res -> 
        Fable.Core.JS.console.log res
        model, Cmd.none

let view = React.functionComponent (fun (input: {| model: Model; dispatch: Msg -> unit |}) ->
    Html.div [
        Html.button [
            prop.onClick <| fun _ -> input.dispatch SendAlert
            prop.text "Test!"
        ]
    ])

let render () = React.elmishComponent("SWALTest", init(), update, (fun model dispatch -> view {| model = model; dispatch = dispatch |}))
