[<RequireQualifiedAccess>]
module Samples.Elmish.DynamicQueue

open Elmish
open Feliz
open Feliz.ElmishComponents
open Feliz.SweetAlert
open Fable.SimpleJson
open Fable.SimpleHttp
open Zanaptak.TypedCssClasses

type Bulma = CssClasses<"https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.5/css/bulma.min.css", Naming.PascalCase>

type Model = { Ip: string option }

let init () = { Ip = None }, Cmd.none

type Msg =
    | GetIP
    | RecieveIP of string option
    | StartQueue

type RespJson =
    { ip: string }

let getIp dispatch =
    async {
        let! (statusCode, responseText) = 
            Http.get "https://api.ipify.org?format=json"

        if statusCode = 200 then
            responseText
            |> Json.parseAs<RespJson>
            |> fun res -> res.ip
            |> Some
        else None
        |> RecieveIP
        |> dispatch

    } |> Async.StartImmediate

let update msg model =
    match msg with
    | GetIP -> model, Cmd.ofSub getIp
    | RecieveIP ipOpt ->
        { model with Ip = ipOpt },
        match ipOpt with
        | Some ip -> 
            [ swal.text ip
              swal.icon.info ]
        | None -> 
            [ swal.text "Uh oh! (probably blocked by AdBlocker)"
              swal.icon.error ]
        |> Cmd.Swal.insertQueueStep
    | StartQueue ->
        model,
        Cmd.batch [
            Cmd.ofMsg GetIP
            Cmd.Swal.queue [
                swal.title "Your public IP"
                swal.confirmButtonText "Show my public IP"
                swal.text "Your IP will be fetched via Fable.SimpleHttp!"
                swal.showLoaderOnConfirm true
            ]
        ]

let view = React.functionComponent (fun (input: {| model: Model; dispatch: Msg -> unit |}) ->
    Html.div [
        prop.className Bulma.Control
        prop.style [
            style.paddingLeft (length.em 8)
            style.paddingBottom (length.em 1)
        ]
        prop.children [
            Html.button [
                prop.classes [ Bulma.Button; Bulma.HasBackgroundPrimary; Bulma.HasTextWhite; Bulma.IsLarge ]
                prop.onClick <| fun _ -> input.dispatch StartQueue
                prop.text "Fire!"
            ]
        ]
    ])

let render () = React.elmishComponent("ElmishDynamicQueue",init(), update, (fun model dispatch -> view {| model = model; dispatch = dispatch |}))
