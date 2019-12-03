namespace Feliz.SweetAlert

open Browser.Types
open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop
open Feliz

[<Erase>]
type showClass =
    static member inline popup (value: string) = Interop.mkSwalShowClassAttr "popup" value
    static member inline popup (value: string list) = Interop.mkSwalShowClassAttr "popup" (value |> String.concat " ")
    static member inline backdrop (value: string) = Interop.mkSwalShowClassAttr "backdrop" value
    static member inline backdrop (value: string list) = Interop.mkSwalShowClassAttr "backdrop" (value |> String.concat " ")
    static member inline icon (value: string) = Interop.mkSwalShowClassAttr "icon" value
    static member inline icon (value: string list) = Interop.mkSwalShowClassAttr "icon" (value |> String.concat " ")

[<Erase>]
type hideClass =
    static member inline popup (value: string) = Interop.mkSwalHideClassAttr "popup" value
    static member inline popup (value: string list) = Interop.mkSwalHideClassAttr "popup" (value |> String.concat " ")
    static member inline backdrop (value: string) = Interop.mkSwalHideClassAttr "backdrop" value
    static member inline backdrop (value: string list) = Interop.mkSwalHideClassAttr "backdrop" (value |> String.concat " ")
    static member inline icon (value: string) = Interop.mkSwalHideClassAttr "icon" value
    static member inline icon (value: string list) = Interop.mkSwalHideClassAttr "icon" (value |> String.concat " ")

[<Erase>]
type CustomClass =
    static member inline container (value: string) = Interop.mkSwalCustomClassAttr "container" value
    static member inline container (value: string list) = Interop.mkSwalCustomClassAttr "container" (value |> String.concat " ")
    static member inline popup (value: string) = Interop.mkSwalCustomClassAttr "popup" value
    static member inline popup (value: string list) = Interop.mkSwalCustomClassAttr "popup" (value |> String.concat " ")
    static member inline header (value: string) = Interop.mkSwalCustomClassAttr "header" value
    static member inline header (value: string list) = Interop.mkSwalCustomClassAttr "header" (value |> String.concat " ")
    static member inline title (value: string) = Interop.mkSwalCustomClassAttr "title" value
    static member inline title (value: string list) = Interop.mkSwalCustomClassAttr "title" (value |> String.concat " ")
    static member inline closeButton (value: string) = Interop.mkSwalCustomClassAttr "closeButton" value
    static member inline closeButton (value: string list) = Interop.mkSwalCustomClassAttr "closeButton" (value |> String.concat " ")
    static member inline icon (value: string) = Interop.mkSwalCustomClassAttr "icon" value
    static member inline icon (value: string list) = Interop.mkSwalCustomClassAttr "icon" (value |> String.concat " ")
    static member inline image (value: string) = Interop.mkSwalCustomClassAttr "image" value
    static member inline image (value: string list) = Interop.mkSwalCustomClassAttr "image" (value |> String.concat " ")
    static member inline content (value: string) = Interop.mkSwalCustomClassAttr "content" value
    static member inline content (value: string list) = Interop.mkSwalCustomClassAttr "content" (value |> String.concat " ")
    static member inline input (value: string) = Interop.mkSwalCustomClassAttr "input" value
    static member inline input (value: string list) = Interop.mkSwalCustomClassAttr "input" (value |> String.concat " ")
    static member inline actions (value: string) = Interop.mkSwalCustomClassAttr "actions" value
    static member inline actions (value: string list) = Interop.mkSwalCustomClassAttr "actions" (value |> String.concat " ")
    static member inline confirmButton (value: string) = Interop.mkSwalCustomClassAttr "confirmButton" value
    static member inline confirmButton (value: string list) = Interop.mkSwalCustomClassAttr "confirmButton" (value |> String.concat " ")
    static member inline cancelButton (value: string) = Interop.mkSwalCustomClassAttr "cancelButton" value
    static member inline cancelButton (value: string list) = Interop.mkSwalCustomClassAttr "cancelButton" (value |> String.concat " ")
    static member inline footer (value: string) = Interop.mkSwalCustomClassAttr "footer" value
    static member inline footer (value: string list) = Interop.mkSwalCustomClassAttr "footer" (value |> String.concat " ")

[<Erase>]
type swal =
    static member inline title (value: string) = Interop.mkSwalAttr "title" value
    static member inline title (value: HTMLElement) = Interop.mkSwalAttr "title" value
    static member inline title (value: ReactElement) = Interop.mkSwalAttr "title" value
    static member inline titleText (value: ReactElement) = Interop.mkSwalAttr "titleText" value
    static member inline html (value: string) = Interop.mkSwalAttr "html" value
    static member inline html (value: HTMLElement) = Interop.mkSwalAttr "html" value
    static member inline html (value: ReactElement) = Interop.mkSwalAttr "html" value
    static member inline text (value: string) = Interop.mkSwalAttr "text" value
    static member inline iconHtml (value: string) = Interop.mkSwalAttr "iconHtml" value
    static member inline showClass (value: ISwalShowClassProperty) = Interop.mkSwalAttr "showClass" (createObj !![ value ])
    static member inline showClass (value: ISwalShowClassProperty list) = Interop.mkSwalAttr "showClass" (createObj !!value)
    static member inline hideClass (value: ISwalHideClassProperty) = Interop.mkSwalAttr "hideClass" (createObj !![ value ])
    static member inline hideClass (value: ISwalHideClassProperty list) = Interop.mkSwalAttr "hideClass" (createObj !!value)
    static member inline footer (value: string) = Interop.mkSwalAttr "footer" value
    static member inline footer (value: HTMLElement) = Interop.mkSwalAttr "footer" value
    static member inline footer (value: ReactElement) = Interop.mkSwalAttr "footer" value
    static member inline backdrop (value: bool) = Interop.mkSwalAttr "backdrop" value
    static member inline backdrop (value: string) = Interop.mkSwalAttr "backdrop" value
    static member inline toast (value: bool) = Interop.mkSwalAttr "toast" value
    static member inline target (value: HTMLElement) = Interop.mkSwalAttr "target" value
    static member inline target (value: string) = Interop.mkSwalAttr "target" value
    static member inline width (value: Styles.ICssUnit) = Interop.mkSwalAttr "width" value
    static member inline width (value: float) = Interop.mkSwalAttr "width" value
    static member inline width (value: int) = Interop.mkSwalAttr "width" value
    static member inline padding (value: Styles.ICssUnit) = Interop.mkSwalAttr "padding" value
    static member inline padding (value: float) = Interop.mkSwalAttr "padding" value
    static member inline padding (value: int) = Interop.mkSwalAttr "padding" value
    static member inline background (value: IStyleAttribute) = Interop.mkSwalAttr "background" (Bindings.getKVV value)
    static member inline background (value: IStyleAttribute list) = Interop.mkSwalAttr "background" (createObj !!(value |> List.map Bindings.getKVV))
    static member inline customClass (value: ISwalCustomClassProperty) = Interop.mkSwalAttr "customClass" (createObj !![ value ])
    static member inline customClass (value: ISwalCustomClassProperty list) = Interop.mkSwalAttr "customClass" (createObj !!value)
    static member inline timer (value: float) = Interop.mkSwalAttr "timer" value
    static member inline timer (value: int) = Interop.mkSwalAttr "timer" value
    static member inline timerProgressBar (value: bool) = Interop.mkSwalAttr "timerProgressBar" value
    static member inline heightAuto (value: bool) = Interop.mkSwalAttr "heightAuto" value
    static member inline allowOutsideClick (value: bool) = Interop.mkSwalAttr "allowOutsideClick" value
    static member inline allowOutsideClick (handler: unit -> bool) = Interop.mkSwalAttr "allowOutsideClick" handler
    static member inline allowEscapeKey (value: bool) = Interop.mkSwalAttr "allowEscapeKey" value
    static member inline allowEscapeKey (handler: unit -> bool) = Interop.mkSwalAttr "allowEscapeKey" handler
    static member inline allowEnterKey (value: bool) = Interop.mkSwalAttr "allowEnterKey" value
    static member inline allowEnterKey (handler: unit -> bool) = Interop.mkSwalAttr "allowEnterKey" handler
    static member inline stopKeydownPropagation (value: bool) = Interop.mkSwalAttr "stopKeydownPropagation" value
    static member inline keydownListenerCapture (value: bool) = Interop.mkSwalAttr "keydownListenerCapture" value
    static member inline showConfirmButton (value: bool) = Interop.mkSwalAttr "showConfirmButton" value
    static member inline showCancelButton (value: bool) = Interop.mkSwalAttr "showCancelButton" value
    static member inline confirmButtonText (value: string) = Interop.mkSwalAttr "confirmButtonText" value
    static member inline confirmButtonText (value: ReactElement) = Interop.mkSwalAttr "confirmButtonText" value
    static member inline cancelButtonText (value: string) = Interop.mkSwalAttr "cancelButtonText" value
    static member inline cancelButtonText (value: ReactElement) = Interop.mkSwalAttr "cancelButtonText" value
    static member inline confirmButtonColor (value: string) = Interop.mkSwalAttr "confirmButtonColor" value
    static member inline cancelButtonColor (value: string) = Interop.mkSwalAttr "cancelButtonColor" value
    static member inline confirmButtonAriaLabel (value: string) = Interop.mkSwalAttr "confirmButtonAriaLabel" value
    static member inline cancelButtonAriaLabel (value: string) = Interop.mkSwalAttr "cancelButtonAriaLabel" value
    static member inline buttonsStyling (value: bool) = Interop.mkSwalAttr "buttonsStyling" value
    static member inline reverseButtons (value: bool) = Interop.mkSwalAttr "reverseButtons" value
    static member inline focusConfirm (value: bool) = Interop.mkSwalAttr "focusConfirm" value
    static member inline focusCancel (value: bool) = Interop.mkSwalAttr "focusCancel" value
    static member inline showCloseButton (value: bool) = Interop.mkSwalAttr "showCloseButton" value
    static member inline closeButtonHtml (value: string) = Interop.mkSwalAttr "closeButtonHtml" value
    static member inline closeButtonAriaLabel (value: string) = Interop.mkSwalAttr "closeButtonAriaLabel" value
    static member inline showLoaderOnConfirm (value: bool) = Interop.mkSwalAttr "showLoaderOnConfirm" value
    static member inline scrollbarPadding (value: bool) = Interop.mkSwalAttr "scrollbarPadding" value
    static member inline preConfirm<'TInput,'TOutput> (handler: 'TInput -> 'TOutput) = Interop.mkSwalAttr "preConfirm" handler
    static member inline preConfirm<'TInput,'TOutput> (handler: 'TInput -> Promise<'TOutput>) = Interop.mkSwalAttr "preConfirm" handler
    static member inline imageUrl (value: string) = Interop.mkSwalAttr "imageUrl" value
    static member inline imageWidth (value: float) = Interop.mkSwalAttr "imageWidth" value
    static member inline imageWidth (value: int) = Interop.mkSwalAttr "imageWidth" value
    static member inline imageHeight (value: float) = Interop.mkSwalAttr "imageHeight" value
    static member inline imageHeight (value: int) = Interop.mkSwalAttr "imageHeight" value
    static member inline imageAlt (value: string) = Interop.mkSwalAttr "imageAlt" value
    static member inline inputPlaceholder (value: string) = Interop.mkSwalAttr "inputPlaceholder" value
    static member inline inputValue (value: string) = Interop.mkSwalAttr "inputValue" value
    static member inline inputValue (value: Promise<string>) = Interop.mkSwalAttr "inputValue" value
    static member inline inputOptions (value: Map<'K,'V>) = Interop.mkSwalAttr "inputOptions" value
    static member inline inputOptions (value: Promise<Map<'K,'V>>) = Interop.mkSwalAttr "inputOptions" value
    static member inline inputAutoTrim (value: bool) = Interop.mkSwalAttr "inputAutoTrim" value
    static member inline inputAttributes (value: IReactProperty) = Interop.mkSwalAttr "inputAttributes" (createObj !![ value ])
    static member inline inputAttributes (values: IReactProperty list) = Interop.mkSwalAttr "inputAttributes" (createObj !!values)
    static member inline inputValidator (handler: string -> Result<unit,string>) = Interop.mkSwalAttr "inputValidator" handler
    static member inline inputValidator (handler: string -> Promise<Result<unit,string>>) = Interop.mkSwalAttr "inputValidator" handler
    static member inline validationMessage (value: string) = Interop.mkSwalAttr "validationMessage" value
    static member inline progressSteps (value: seq<string>) = Interop.mkSwalAttr "progressSteps" (value |> ResizeArray)
    static member inline currentProgressStep (value: string) = Interop.mkSwalAttr "currentProgressStep" value
    static member inline progressStepsDistance (value: string) = Interop.mkSwalAttr "progressStepsDistance" value
    static member inline onBeforeOpen (handler: HTMLElement -> unit) = Interop.mkSwalAttr "onBeforeOpen" handler
    static member inline onOpen (handler: HTMLElement -> unit) = Interop.mkSwalAttr "onOpen" handler
    static member inline onRender (handler: HTMLElement -> unit) = Interop.mkSwalAttr "onRender" handler
    static member inline onClose (handler: HTMLElement -> unit) = Interop.mkSwalAttr "onClose" handler
    static member inline onAfterClose (handler: unit -> unit) = Interop.mkSwalAttr "onAfterClose" handler    

module swal = 
    [<Erase>]
    type icon =
        static member inline success = Interop.mkSwalAttr "icon" "success"
        static member inline error = Interop.mkSwalAttr "icon" "error"
        static member inline warning = Interop.mkSwalAttr "icon" "warning"
        static member inline info = Interop.mkSwalAttr "icon" "info"
        static member inline question = Interop.mkSwalAttr "icon" "question"

    [<Erase>]
    type input =
        static member inline checkbox = Interop.mkSwalAttr "input" "checkbox"
        static member inline email = Interop.mkSwalAttr "input" "email"
        static member inline file = Interop.mkSwalAttr "input" "file"
        static member inline password = Interop.mkSwalAttr "input" "password"
        static member inline number = Interop.mkSwalAttr "input" "number"
        static member inline radio = Interop.mkSwalAttr "input" "radio"
        static member inline range = Interop.mkSwalAttr "input" "range"
        static member inline select = Interop.mkSwalAttr "input" "select"
        static member inline tel = Interop.mkSwalAttr "input" "tel"
        static member inline text = Interop.mkSwalAttr "input" "text"
        static member inline url = Interop.mkSwalAttr "input" "url"

    [<Erase>]
    type position =
        static member inline top = Interop.mkSwalAttr "position" "top"
        static member inline topStart = Interop.mkSwalAttr "position" "top-start"
        static member inline topEnd = Interop.mkSwalAttr "position" "top-end"
        static member inline topRight = Interop.mkSwalAttr "position" "top-right"
        static member inline center = Interop.mkSwalAttr "position" "center"
        static member inline centerStart = Interop.mkSwalAttr "position" "center-start"
        static member inline centerEnd = Interop.mkSwalAttr "position" "center-end"
        static member inline centerLeft = Interop.mkSwalAttr "position" "center-left"
        static member inline centerRight = Interop.mkSwalAttr "position" "center-right"
        static member inline bottom = Interop.mkSwalAttr "position" "bottom"
        static member inline bottomStart = Interop.mkSwalAttr "position" "bottom-start"
        static member inline bottomEnd = Interop.mkSwalAttr "position" "bottom-end"
        static member inline bottomLeft = Interop.mkSwalAttr "position" "bottom-left"
        static member inline bottomRight = Interop.mkSwalAttr "position" "bottom-right"
        
    [<Erase>]
    type grow =
        static member inline row = Interop.mkSwalAttr "grow" "row"
        static member inline column = Interop.mkSwalAttr "grow" "column"
        static member inline fullscreen = Interop.mkSwalAttr "grow" "fullscreen"
        static member inline false' = Interop.mkSwalAttr "grow" false
