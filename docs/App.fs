module App

open Elmish
open Elmish.React
open Fable.React
open Feliz
open Feliz.Markdown
open Fable.SimpleHttp
open Feliz.Router
open Fable.Core
open Fable.Core.JsInterop
open Zanaptak.TypedCssClasses

type Bulma = CssClasses<"https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.5/css/bulma.min.css", Naming.PascalCase>
type FA = CssClasses<"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css", Naming.PascalCase>

type Highlight =
    static member inline highlight (properties: IReactProperty list) =
        Interop.reactApi.createElement(importDefault "react-highlight", createObj !!properties)

type State = 
    { CurrentPath : string list
      CurrentTab: string list }

let init () = 
    { CurrentPath = [ ]
      CurrentTab = [ ] }, Cmd.none

type Msg =
    | TabToggled of string list
    | UrlChanged of string list

let update msg state =
    match msg with
    | UrlChanged segments -> 
        { state with CurrentPath = segments }, 
        match state.CurrentTab with
        | [ ] when segments.Length > 2 -> 
            segments
            |> TabToggled
            |> Cmd.ofMsg
        | _ -> Cmd.none
    | TabToggled tabs ->
        match tabs with
        | [ ] -> { state with CurrentTab = [ ] }, Cmd.none
        | _ -> { state with CurrentTab = tabs }, Cmd.none

let centeredSpinner =
    Html.div [
        prop.style [
            style.textAlign.center
            style.marginLeft length.auto
            style.marginRight length.auto
            style.marginTop 50
        ]
        prop.children [
            Html.li [
                prop.className [
                    FA.Fa
                    FA.FaRefresh
                    FA.FaSpin
                    FA.Fa3X
                ]
            ]
        ]
    ]

let samples = 
    let elmishSamples =
        [ "swal-elmish-simple", Samples.Elmish.Simple.render()
          "swal-elmish-reactandhandler", Samples.Elmish.ReactAndHandler.render()
          "swal-elmish-dynamicqueue", Samples.Elmish.DynamicQueue.render() ]

    let simpleSamples =
        [ "swal-simple-basic", Samples.Simple.Basic.render()
          "swal-simple-withtitles", Samples.Simple.WithTitles.render()
          "swal-simple-withhandlers", Samples.Simple.WithHandlers.render() ]      

    let mainSamples =
        [ "swal-react", Samples.React.render()
          "swal-inputtypes", Samples.InputTypes.render()
          "swal-animation", Samples.Animation.render() 
          "swal-image", Samples.Image.render() 
          "swal-closetimer", Samples.CloseTimer.render() 
          "swal-dynamicqueue", Samples.DynamicQueue.render() ]

    [ elmishSamples; simpleSamples; mainSamples ]
    |> List.concat

let githubPath (rawPath: string) =
    let parts = rawPath.Split('/')
    if parts.Length > 5
    then sprintf "http://www.github.com/%s/%s" parts.[3] parts.[4]
    else rawPath

/// Renders a code block from markdown using react-highlight.
/// Injects sample React components when the code block has language of the format <language>:<sample-name>
let codeBlockRenderer (codeProps: Markdown.ICodeProperties) =
    if codeProps.language <> null && codeProps.language.Contains ":" then
        let languageParts = codeProps.language.Split(':')
        let sampleName = languageParts.[1]
        let sampleApp =
            samples
            |> List.tryFind (fun (name, _) -> name = sampleName)
            |> Option.map snd
            |> Option.defaultValue (Html.h1 [
                prop.style [ style.color.crimson ];
                prop.text (sprintf "Could not find sample app '%s'" sampleName)
            ])
        Html.div [
            sampleApp
            Highlight.highlight [
                prop.className "fsharp"
                prop.text(codeProps.value)
            ]
        ]
    else
        Highlight.highlight [
            prop.className "fsharp"
            prop.text(codeProps.value)
        ]

let renderMarkdown (path: string) (content: string) =
    Html.div [
        prop.className [ Bulma.Content; "scrollbar" ]
        prop.style [ 
            style.width (length.percent 100)
            style.padding (0,20)
        ]
        prop.children [
            if path.StartsWith "https://raw.githubusercontent.com" then
                Html.h2 [
                    Html.i [ prop.className [ FA.Fa; FA.FaGithub ] ]
                    Html.anchor [
                        prop.style [ style.marginLeft 10; style.color.lightGreen ]
                        prop.href (githubPath path)
                        prop.text "View on Github"
                    ]
                ]

            Markdown.markdown [
                markdown.source content
                markdown.escapeHtml false
                markdown.renderers [
                    markdown.renderers.code codeBlockRenderer
                ]
            ]
        ]
    ]

module MarkdownLoader =

    open Feliz.ElmishComponents

    type State =
        | Initial
        | Loading
        | Errored of string
        | LoadedMarkdown of content: string

    type Msg =
        | StartLoading of path: string list
        | Loaded of Result<string, int * string>

    let init (path: string list) = Initial, Cmd.ofMsg (StartLoading path)

    let resolvePath = function
    | [ one: string ] when one.StartsWith "http" -> one
    | segments -> String.concat "/" segments

    let update (msg: Msg) (state: State) =
        match msg with
        | StartLoading path ->
            let loadMarkdownAsync() = async {
                let! (statusCode, responseText) = Http.get (resolvePath path)
                if statusCode = 200
                then return Loaded (Ok responseText)
                else return Loaded (Error (statusCode, responseText))
            }

            Loading, Cmd.OfAsync.perform loadMarkdownAsync () id

        | Loaded (Ok content) ->
            State.LoadedMarkdown content, Cmd.none

        | Loaded (Error (status, _)) ->
            State.LoadedMarkdown (sprintf "Status %d: could not load markdown" status), Cmd.none

    let render path (state: State) dispatch =
        match state with
        | Initial -> Html.none
        | Loading -> centeredSpinner
        | LoadedMarkdown content -> renderMarkdown (resolvePath path) content
        | Errored error ->
            Html.h1 [
                prop.style [ style.color.crimson ]
                prop.text error
            ]

    let loadMarkdown' (path: string list) =
        React.elmishComponent("LoadMarkdown", init path, update, render path, key = resolvePath path)

let loadMarkdown (path: string list) = MarkdownLoader.loadMarkdown' path

// A collapsable nested menu for the sidebar
// keeps internal state on whether the items should be visible or not based on the collapsed state
let nestedMenuList' = FunctionComponent.Of((fun (state: State, name: string, basePath: string list, elems: (string list -> Fable.React.ReactElement) list, dispatch) ->
    let collapsed = 
        match state.CurrentTab with
        | [ ] -> false
        | _ -> 
            basePath 
            |> List.indexed 
            |> List.forall (fun (i, segment) -> 
                List.tryItem i state.CurrentTab 
                |> Option.map ((=) segment) 
                |> Option.defaultValue false) 

    Html.li [
        Html.anchor [
            prop.className Bulma.IsUnselectable
            prop.onClick <| fun _ -> 
                match collapsed with
                | true -> dispatch <| TabToggled (basePath |> List.rev |> List.tail |> List.rev)
                | false -> dispatch <| TabToggled basePath
            prop.children [
                Html.i [
                    prop.style [ style.marginRight 10 ]
                    prop.className [
                        FA.Fa
                        if not collapsed then FA.FaAngleDown else FA.FaAngleUp
                    ]
                ]
                Html.span name
            ]
        ]

        Html.ul [
            prop.className Bulma.MenuList
            prop.style [ 
                if not collapsed then yield! [ style.display.none ] 
            ]
            prop.children (elems |> List.map (fun f -> f basePath))
        ]
    ]), memoizeWith = memoEqualsButFunctions)

let sidebar (state: State) dispatch =
    let nestedMenuList (name: string) (basePath: string list) (items: (string list -> Fable.React.ReactElement) list) =
        nestedMenuList'(state, name, basePath, items, dispatch)

    let subNestedMenuList (name: string) (basePath: string list) (items: (string list -> Fable.React.ReactElement) list) (addedBasePath: string list) =
        nestedMenuList'(state, name, (addedBasePath @ basePath), items, dispatch)

    // top level label
    let menuLabel (content: string) =
        Html.p [
            prop.className [ Bulma.MenuLabel; Bulma.IsUnselectable ]
            prop.text content
        ]

    // top level menu
    let menuList (items: Fable.React.ReactElement list) =
        Html.ul [
            prop.className Bulma.MenuList
            prop.style [ style.width (length.percent 95) ]
            prop.children items
        ]

    let menuItem (name: string) (path: string list) =
        Html.li [
            Html.anchor [
                prop.className [
                    state.CurrentPath = path, Bulma.IsActive
                    state.CurrentPath = path, Bulma.HasBackgroundPrimary
                ]
                prop.text name
                prop.href (sprintf "#/%s" (String.concat "/" path))
            ]
        ]

    let nestedMenuItem (name: string) (extendedPath: string list) (basePath: string list) =
        let path = basePath @ extendedPath
        Html.li [
            Html.anchor [
                prop.className [
                    state.CurrentPath = path, Bulma.IsActive
                    state.CurrentPath = path, Bulma.HasBackgroundPrimary
                ]
                prop.text name
                prop.href (sprintf "#/%s" (String.concat "/" path))
            ]
        ]

    let allItems =
        Html.div [
            prop.className "scrollbar"
            prop.children [
                menuList [
                    menuItem "Overview" [ ]
                    menuItem "Installation" [ Urls.SweetAlert; Urls.Installation ]
                    menuItem "Release Notes" [ Urls.SweetAlert; Urls.ReleaseNotes ]
                    menuItem "Contributing" [ Urls.SweetAlert; Urls.Contributing ]
                    menuLabel "Examples"
                    nestedMenuList "Elmish" [ Urls.SweetAlert; Urls.Examples; Urls.Elmish ] [
                        nestedMenuItem "Simple" [ Urls.Simple ]
                        nestedMenuItem "React and Handling" [ Urls.ReactAndHandler ]
                        nestedMenuItem "Dynamic Queue" [ Urls.DynamicQueue ]
                    ]
                    nestedMenuList "Simple" [ Urls.SweetAlert; Urls.Examples; Urls.Simple ] [
                        nestedMenuItem "Basic" [ Urls.Basic ]
                        nestedMenuItem "With Titles" [ Urls.WithTitles ]
                        nestedMenuItem "With Handlers" [ Urls.WithHandlers ]
                    ]
                    menuItem "With React" [ Urls.SweetAlert; Urls.Examples; Urls.React ]
                    menuItem "Input Types" [ Urls.SweetAlert; Urls.Examples; Urls.InputTypes ]
                    menuItem "Custom Animation" [ Urls.SweetAlert; Urls.Examples; Urls.Animation ]
                    menuItem "Image" [ Urls.SweetAlert; Urls.Examples; Urls.Image ]
                    menuItem "Close Timer" [ Urls.SweetAlert; Urls.Examples; Urls.CloseTimer ]
                    menuItem "Dynamic Queue" [ Urls.SweetAlert; Urls.Examples; Urls.DynamicQueue ]
                ]
            ]
        ]

    // the actual nav bar
    Html.aside [
        prop.className Bulma.Menu
        prop.style [
            style.width (length.perc 100)
        ]
        prop.children [ menuLabel "Feliz.SweetAlert"; allItems ]
    ]

let readme = sprintf "https://raw.githubusercontent.com/%s/%s/master/README.md"
let contributing = sprintf "https://raw.githubusercontent.com/Zaid-Ajaj/Feliz/master/public/Feliz/Contributing.md"

let elmishExamples (currentPath: string list) =
    match currentPath with
    | [ Urls.Simple ] -> [ "Simple.md" ]
    | [ Urls.ReactAndHandler ] -> [ "ReactAndHandler.md" ]
    | [ Urls.DynamicQueue ] -> [ "DynamicQueue.md" ]
    | _ -> [ ]
    |> fun path ->
        if path |> List.isEmpty then []
        else [ Urls.Elmish ] @ path

let simpleExamples (currentPath: string list) =
    match currentPath with
    | [ Urls.Basic ] -> [ "Basic.md" ]
    | [ Urls.WithTitles ] -> [ "WithTitles.md" ]
    | [ Urls.WithHandlers ] -> [ "WithHandlers.md" ]
    | _ -> [ ]
    |> fun path ->
        if path |> List.isEmpty then []
        else [ Urls.Simple ] @ path

let content state dispatch =
    let tryTakePath (basePath: string list) (path: string list) =
        let num = path.Length
        if basePath.Length >= num then
            basePath |> List.take num = path
        else false

    match state.CurrentPath with
    | [ Urls.SweetAlert; Urls.Overview; ] -> lazyView loadMarkdown [ "SweetAlert"; "README.md" ]
    | [ Urls.SweetAlert; Urls.Installation ] -> lazyView loadMarkdown [ "SweetAlert"; "Installation.md" ]
    | [ Urls.SweetAlert; Urls.ReleaseNotes ] -> lazyView loadMarkdown [ "SweetAlert"; "RELEASE_NOTES.md" ]
    | [ Urls.SweetAlert; Urls.Contributing ] -> lazyView loadMarkdown [ contributing ]
    | _ when tryTakePath state.CurrentPath [ Urls.SweetAlert; Urls.Examples ] -> 
        match state.CurrentPath |> List.skip 2 with
        | elmishPath when tryTakePath elmishPath [ Urls.Elmish ] -> elmishPath |> List.skip 1 |> elmishExamples
        | simplePath when tryTakePath simplePath [ Urls.Simple ] -> simplePath |> List.skip 1 |> simpleExamples
        | [ Urls.React ] -> [ "React.md" ]
        | [ Urls.InputTypes ] -> [ "InputTypes.md" ]
        | [ Urls.Animation ] -> [ "Animation.md" ]
        | [ Urls.Image ] -> [ "Image.md" ]
        | [ Urls.CloseTimer ] -> [ "CloseTimer.md" ]
        | [ Urls.DynamicQueue ] -> [ "DynamicQueue.md" ]
        | _ -> [ ]
        |> fun path ->
            if path |> List.isEmpty then Html.div [ for segment in state.CurrentPath -> Html.p segment ]
            else [ Urls.SweetAlert; Urls.Examples ] @ path |> (lazyView loadMarkdown)
    | _ -> lazyView loadMarkdown [ "SweetAlert"; "README.md" ]

let main state dispatch =
    Html.div [
        prop.className [ Bulma.Tile; Bulma.IsAncestor ]
        prop.children [
            Html.div [
                prop.className [ Bulma.Tile; Bulma.Is2 ]
                prop.children [ sidebar state dispatch ]
            ]

            Html.div [
                prop.className Bulma.Tile
                prop.style [ style.paddingTop 30 ]
                prop.children [ content state dispatch ]
            ]
        ]
    ]

let render (state: State) dispatch =
    let application =
        Html.div [
            prop.style [ 
                style.padding 30
            ]
            prop.children [ main state dispatch ]
        ]

    Router.router [
        Router.onUrlChanged (UrlChanged >> dispatch)
        Router.application application
    ]

Program.mkProgram init update render
|> Program.withReactSynchronous "root"
|> Program.withConsoleTrace
|> Program.run
