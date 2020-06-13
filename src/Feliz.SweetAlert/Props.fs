namespace Feliz.SweetAlert

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open Feliz
open FSharp.Core

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
type customClass =
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
    /// The title of the modal, as HTML.
    static member inline title (value: string) = Interop.mkSwalAttr "title" value

    /// The title of the modal, as HTML.
    static member inline title (value: HTMLElement) = Interop.mkSwalAttr "title" value

    /// The title of the modal, as HTML.
    static member inline title (value: ReactElement) = Interop.mkSwalAttr "title" value

    /// The title of the modal, as text. Useful to avoid HTML injection.
    static member inline titleText (value: string) = Interop.mkSwalAttr "titleText" value

    /// A HTML description for the modal.
    static member inline html (value: string) = Interop.mkSwalAttr "html" value

    /// A HTML description for the modal.
    static member inline html (value: HTMLElement) = Interop.mkSwalAttr "html" value

    /// A HTML description for the modal.
    static member inline html (value: ReactElement) = Interop.mkSwalAttr "html" value

    /// A description for the modal. 
    ///
    /// If "text" and "html" parameters are provided in the same time, "text" will be used.
    static member inline text (value: string) = Interop.mkSwalAttr "text" value

    /// The custom HTML content for an icon.
    static member inline iconHtml (value: string) = Interop.mkSwalAttr "iconHtml" value

    /// CSS classes for animations when showing a popup (fade in)
    static member inline showClass (value: ISwalShowClassProperty) = Interop.mkSwalAttr "showClass" (createObj !![ value ])

    /// CSS classes for animations when showing a popup (fade in)
    static member inline showClass (value: ISwalShowClassProperty list) = Interop.mkSwalAttr "showClass" (createObj !!value)

    /// CSS classes for animations when hiding a popup (fade out)
    static member inline hideClass (value: ISwalHideClassProperty) = Interop.mkSwalAttr "hideClass" (createObj !![ value ])

    /// CSS classes for animations when hiding a popup (fade out)
    static member inline hideClass (value: ISwalHideClassProperty list) = Interop.mkSwalAttr "hideClass" (createObj !!value)

    /// The footer of the modal.
    static member inline footer (value: string) = Interop.mkSwalAttr "footer" value

    /// The footer of the modal.
    static member inline footer (value: HTMLElement) = Interop.mkSwalAttr "footer" value

    /// The footer of the modal.
    static member inline footer (value: ReactElement) = Interop.mkSwalAttr "footer" value

    /// Whether or not SweetAlert2 should show a full screen click-to-dismiss backdrop. Can be either a boolean or a string which will be assigned to the CSS background property.
    static member inline backdrop (value: bool) = Interop.mkSwalAttr "backdrop" value

    /// Whether or not SweetAlert2 should show a full screen click-to-dismiss backdrop. Can be either a boolean or a string which will be assigned to the CSS background property.
    static member inline backdrop (value: string) = Interop.mkSwalAttr "backdrop" value

    /// Whether or not an alert should be treated as a toast notification. This option is normally coupled with the position parameter and a timer. 
    ///
    /// Toasts are NEVER autofocused.
    static member inline toast (value: bool) = Interop.mkSwalAttr "toast" value

    /// The container element for adding modal into.
    static member inline target (value: HTMLElement) = Interop.mkSwalAttr "target" value

    /// The container element for adding modal into.
    static member inline target (value: string) = Interop.mkSwalAttr "target" value

    /// Modal window width, including paddings (box-sizing: border-box). Can be in px or %. 
    ///
    /// The default width is 32rem.
    static member inline width (value: Styles.ICssUnit) = Interop.mkSwalAttr "width" value

    /// Modal window width, including paddings (box-sizing: border-box). Can be in px or %. 
    ///
    /// The default width is 32rem.
    static member inline width (value: float) = Interop.mkSwalAttr "width" value

    /// Modal window width, including paddings (box-sizing: border-box). Can be in px or %. 
    ///
    /// The default width is 32rem.
    static member inline width (value: int) = Interop.mkSwalAttr "width" value

    /// Modal window padding. 
    ///
    /// The default padding is 1.25rem.
    static member inline padding (value: Styles.ICssUnit) = Interop.mkSwalAttr "padding" value

    /// Modal window padding. 
    ///
    /// The default padding is 1.25rem.
    static member inline padding (value: float) = Interop.mkSwalAttr "padding" value

    /// Modal window padding. 
    ///
    /// The default padding is 1.25rem.
    static member inline padding (value: int) = Interop.mkSwalAttr "padding" value

    /// Modal window background (CSS background property). 
    ///
    /// The default background is '#fff'.
    static member inline background (value: IStyleAttribute) = Interop.mkSwalAttr "background" (Bindings.getKVV value)

    /// Modal window background (CSS background property). 
    ///
    /// The default background is '#fff'.
    static member inline background (value: IStyleAttribute list) = Interop.mkSwalAttr "background" (createObj !!(value |> List.map Bindings.getKVV))

    /// A custom CSS class for the modal.
    static member inline customClass (value: ISwalCustomClassProperty) = Interop.mkSwalAttr "customClass" (createObj !![ value ])

    /// A custom CSS class for the modal.
    static member inline customClass (value: ISwalCustomClassProperty list) = Interop.mkSwalAttr "customClass" (createObj !!value)

    /// Auto close timer of the modal. Set in ms (milliseconds).
    static member inline timer (value: float) = Interop.mkSwalAttr "timer" value

    /// Auto close timer of the modal. Set in ms (milliseconds).
    static member inline timer (value: int) = Interop.mkSwalAttr "timer" value

    /// If set to true, the timer will have a progress bar at the bottom of a popup.
    static member inline timerProgressBar (value: bool) = Interop.mkSwalAttr "timerProgressBar" value

    /// By default, SweetAlert2 sets html's and body's CSS height to auto !important. 
    ///
    /// If this behavior isn't compatible with your project's layout, set heightAuto to false.
    static member inline heightAuto (value: bool) = Interop.mkSwalAttr "heightAuto" value

    /// If set to false, the user can't dismiss the modal by clicking outside it.
    ///
    /// You can also pass a custom function returning a boolean value, e.g. if you want to disable outside clicks for the loading state of a modal.
    static member inline allowOutsideClick (value: bool) = Interop.mkSwalAttr "allowOutsideClick" value

    /// If set to false, the user can't dismiss the modal by clicking outside it.
    ///
    /// You can also pass a custom function returning a boolean value, e.g. if you want to disable outside clicks for the loading state of a modal.
    static member inline allowOutsideClick (handler: unit -> bool) = Interop.mkSwalAttr "allowOutsideClick" handler

    /// If set to false, the user can't dismiss the modal by pressing the Esc key. 
    ///
    /// You can also pass a custom function returning a boolean value, e.g. if you want to disable the Esc key for the loading state of a modal.
    static member inline allowEscapeKey (value: bool) = Interop.mkSwalAttr "allowEscapeKey" value

    /// If set to false, the user can't dismiss the modal by pressing the Esc key. 
    ///
    /// You can also pass a custom function returning a boolean value, e.g. if you want to disable the Esc key for the loading state of a modal.
    static member inline allowEscapeKey (handler: unit -> bool) = Interop.mkSwalAttr "allowEscapeKey" handler

    /// If set to false, the user can't confirm the modal by pressing the Enter or Space keys, unless they manually focus the confirm button. 
    ///
    /// You can also pass a custom function returning a boolean value.
    static member inline allowEnterKey (value: bool) = Interop.mkSwalAttr "allowEnterKey" value

    /// If set to false, the user can't confirm the modal by pressing the Enter or Space keys, unless they manually focus the confirm button. 
    ///
    /// You can also pass a custom function returning a boolean value.
    static member inline allowEnterKey (handler: unit -> bool) = Interop.mkSwalAttr "allowEnterKey" handler

    /// If set to false, SweetAlert2 will allow keydown events propagation to the document.
    static member inline stopKeydownPropagation (value: bool) = Interop.mkSwalAttr "stopKeydownPropagation" value

    /// By default keydownListenerCapture is false which means when a user hits Esc, both SweetAlert2 and Bootstrap modals will be closed. 
    /// 
    /// Set keydownListenerCapture to true to fix that behavior.
    static member inline keydownListenerCapture (value: bool) = Interop.mkSwalAttr "keydownListenerCapture" value

    /// If set to false, a "Confirm"-button will not be shown. It can be useful when you're using custom HTML description.
    static member inline showConfirmButton (value: bool) = Interop.mkSwalAttr "showConfirmButton" value

    /// If set to true, a "Cancel"-button will be shown, which the user can click on to dismiss the modal.
    static member inline showCancelButton (value: bool) = Interop.mkSwalAttr "showCancelButton" value

    /// Use this to change the text on the "Confirm"-button.
    static member inline confirmButtonText (value: string) = Interop.mkSwalAttr "confirmButtonText" value

    /// Use this to change the text on the "Confirm"-button.
    static member inline confirmButtonText (value: ReactElement) = Interop.mkSwalAttr "confirmButtonText" value

    /// Use this to change the text on the "Cancel"-button.
    static member inline cancelButtonText (value: string) = Interop.mkSwalAttr "cancelButtonText" value

    /// Use this to change the text on the "Cancel"-button.
    static member inline cancelButtonText (value: ReactElement) = Interop.mkSwalAttr "cancelButtonText" value

    /// Use this to change the background color of the "Confirm"-button. 
    ///
    /// The default color is #3085d6
    static member inline confirmButtonColor (value: string) = Interop.mkSwalAttr "confirmButtonColor" value

    /// Use this to change the background color of the "Cancel"-button.
    ///
    /// The default color is #aaa
    static member inline cancelButtonColor (value: string) = Interop.mkSwalAttr "cancelButtonColor" value

    /// Use this to change the aria-label for the "Confirm"-button.
    static member inline confirmButtonAriaLabel (value: string) = Interop.mkSwalAttr "confirmButtonAriaLabel" value

    /// Use this to change the aria-label for the "Cancel"-button.
    static member inline cancelButtonAriaLabel (value: string) = Interop.mkSwalAttr "cancelButtonAriaLabel" value

    /// Apply default styling to buttons. If you want to use your own classes (e.g. Bootstrap classes) set this parameter to false.
    static member inline buttonsStyling (value: bool) = Interop.mkSwalAttr "buttonsStyling" value

    /// Set to true if you want to invert default buttons positions ("Confirm"-button on the right side).
    static member inline reverseButtons (value: bool) = Interop.mkSwalAttr "reverseButtons" value

    /// Set to false if you want to focus the first element in tab order instead of "Confirm"-button by default.
    static member inline focusConfirm (value: bool) = Interop.mkSwalAttr "focusConfirm" value

    /// Set to true if you want to focus the "Cancel"-button by default.
    static member inline focusCancel (value: bool) = Interop.mkSwalAttr "focusCancel" value

    /// Set to true to show close button in top right corner of the modal.
    static member inline showCloseButton (value: bool) = Interop.mkSwalAttr "showCloseButton" value

    /// Use this to change the content of the close button.
    static member inline closeButtonHtml (value: string) = Interop.mkSwalAttr "closeButtonHtml" value

    /// Use this to change the aria-label for the close button.
    static member inline closeButtonAriaLabel (value: string) = Interop.mkSwalAttr "closeButtonAriaLabel" value

    /// Set to true to disable buttons and show that something is loading. 
    ///
    /// Use it in combination with the preConfirm parameter.
    static member inline showLoaderOnConfirm (value: bool) = Interop.mkSwalAttr "showLoaderOnConfirm" value

    /// Set to false to disable body padding adjustment when the page scrollbar gets hidden while the modal is shown
    static member inline scrollbarPadding (value: bool) = Interop.mkSwalAttr "scrollbarPadding" value

    /// Function to execute before confirm.
    /// Returned (or resolved) value can be:
    /// - false to prevent a popup from closing
    /// - anything else to pass that value as the result.value of Swal.fire()
    /// - None to keep the default result.value
    static member inline preConfirm (handler: 'TInput -> 'TOutput) = Interop.mkSwalAttr "preConfirm" handler

    /// Function to execute before confirm.
    /// Returned (or resolved) value can be:
    /// - false to prevent a popup from closing
    /// - anything else to pass that value as the result.value of Swal.fire()
    /// - None to keep the default result.value
    static member inline preConfirm (handler: 'TInput -> JS.Promise<'TOutput>) = Interop.mkSwalAttr "preConfirm" handler

    /// Function to execute before confirm.
    /// Returned (or resolved) value can be:
    /// - false to prevent a popup from closing
    /// - anything else to pass that value as the result.value of Swal.fire()
    /// - None to keep the default result.value
    static member inline preConfirm (handler: 'TInput -> IObservableLike<'TOutput>) = Interop.mkSwalAttr "preConfirm" handler

    /// Add a customized icon for the modal. Should contain a string with the path or URL to the image.
    static member inline imageUrl (value: string) = Interop.mkSwalAttr "imageUrl" value

    /// If imageUrl is set, you can specify imageWidth to describes image width in px.
    static member inline imageWidth (value: float) = Interop.mkSwalAttr "imageWidth" value

    /// If imageUrl is set, you can specify imageWidth to describes image width in px.
    static member inline imageWidth (value: int) = Interop.mkSwalAttr "imageWidth" value

    /// Custom image height in px.
    static member inline imageHeight (value: float) = Interop.mkSwalAttr "imageHeight" value

    /// Custom image height in px.
    static member inline imageHeight (value: int) = Interop.mkSwalAttr "imageHeight" value

    /// An alternative text for the custom image icon.
    static member inline imageAlt (value: string) = Interop.mkSwalAttr "imageAlt" value

    /// Input field placeholder.
    static member inline inputPlaceholder (value: string) = Interop.mkSwalAttr "inputPlaceholder" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: string) = Interop.mkSwalAttr "inputValue" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: JS.Promise<string>) = Interop.mkSwalAttr "inputValue" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: IObservableLike<string>) = Interop.mkSwalAttr "inputValue" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: float) = Interop.mkSwalAttr "inputValue" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: JS.Promise<float>) = Interop.mkSwalAttr "inputValue" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: IObservableLike<float>) = Interop.mkSwalAttr "inputValue" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: int) = Interop.mkSwalAttr "inputValue" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: JS.Promise<int>) = Interop.mkSwalAttr "inputValue" value

    /// Input field initial value.
    ///
    /// If the input type is checkbox, inputValue will represent the checked state.
    ///
    /// If the input type is text, email, number, tel or textarea a Promise can be accepted as inputValue.
    static member inline inputValue (value: IObservableLike<int>) = Interop.mkSwalAttr "inputValue" value


    /// If input parameter is set to "select" or "radio", you can provide options. 
    /// Can be a list or a plain object, with keys that represent option values and values that represent option text, or a Promise that resolves with one of those types.
    static member inline inputOptions (value: ('K * 'V) list) = Interop.mkSwalAttr "inputOptions" (createObj !!value)

    /// If input parameter is set to "select" or "radio", you can provide options. 
    /// Can be a Map or a plain object, with keys that represent option values and values that represent option text, or a Promise that resolves with one of those types.
    static member inline inputOptions (value: obj) = Interop.mkSwalAttr "inputOptions" value
    
    /// If input parameter is set to "select" or "radio", you can provide options. 
    /// Can be a Map or a plain object, with keys that represent option values and values that represent option text, or a Promise that resolves with one of those types.
    static member inline inputOptions (value: JS.Promise<('K * 'V) list>) = 
        value
        |> Promise.map (fun res -> createObj !!res)
        |> Interop.mkSwalAttr "inputOptions"
    
    /// If input parameter is set to "select" or "radio", you can provide options. 
    /// Can be a Map or a plain object, with keys that represent option values and values that represent option text, or a Promise that resolves with one of those types.
    static member inline inputOptions (value: JS.Promise<obj>) = Interop.mkSwalAttr "inputOptions" value

    /// If input parameter is set to "select" or "radio", you can provide options. 
    /// Can be a Map or a plain object, with keys that represent option values and values that represent option text, or a Promise that resolves with one of those types.
    static member inline inputOptions (value: IObservableLike<obj>) = Interop.mkSwalAttr "inputOptions" value

    /// Automatically remove whitespaces from both ends of a result string. Set this parameter to false to disable auto-trimming.
    static member inline inputAutoTrim (value: bool) = Interop.mkSwalAttr "inputAutoTrim" value

    /// HTML input attributes (e.g. min, max, autocomplete, accept), that are added to the input field. 
    ///
    /// Object keys will represent attributes names, object values will represent attributes values.
    static member inline inputAttributes (value: IReactProperty) = Interop.mkSwalAttr "inputAttributes" (createObj !![ value ])

    /// HTML input attributes (e.g. min, max, autocomplete, accept), that are added to the input field. 
    ///
    /// Object keys will represent attributes names, object values will represent attributes values.
    static member inline inputAttributes (values: IReactProperty list) = Interop.mkSwalAttr "inputAttributes" (createObj !!values)

    /// Validator for input field
    ///
    /// Note that the result is if errors occured (e.g. None if validation was correct, or Error "You did it wrong!")
    static member inline inputValidator (handler: string option -> string option) = Interop.mkSwalAttr "inputValidator" handler

    /// Validator for input field
    ///
    /// Note that the result is if errors occured (e.g. None if validation was correct, or Error "You did it wrong!")
    static member inline inputValidator (handler: string option -> JS.Promise<string option>) = Interop.mkSwalAttr "inputValidator" handler
    /// Validator for input field
    ///
    /// Note that the result is if errors occured (e.g. None if validation was correct, or Error "You did it wrong!")
    static member inline inputValidator (handler: string option -> IObservableLike<string option>) = Interop.mkSwalAttr "inputValidator" handler

    /// A custom validation message for default validators (email, url).
    static member inline validationMessage (value: string) = Interop.mkSwalAttr "validationMessage" value

    /// Progress steps, useful for modal queues.
    static member inline progressSteps (value: seq<string>) = Interop.mkSwalAttr "progressSteps" (value |> ResizeArray)

    /// Current active progress step. 
    ///
    /// The default is Swal.getQueueStep()
    static member inline currentProgressStep (value: string) = Interop.mkSwalAttr "currentProgressStep" value

    /// Distance between progress steps.
    ///
    /// The default is 40px
    static member inline progressStepsDistance (value: string) = Interop.mkSwalAttr "progressStepsDistance" value

    /// Function to run when modal built, but not shown yet. Provides modal DOM element.
    static member inline onBeforeOpen (handler: HTMLElement -> unit) = Interop.mkSwalAttr "onBeforeOpen" handler

    /// Function to run when modal opens, provides modal DOM element.
    static member inline onOpen (handler: HTMLElement -> unit) = Interop.mkSwalAttr "onOpen" handler

    /// Function to run after modal DOM has been updated. Typically, this will happen after Swal.fire() or Swal.update(). 
    ///
    /// If you want to perform changes in the modal's DOM, that survive Swal.update(), onRender is a good place for that.
    static member inline onRender (handler: HTMLElement -> unit) = Interop.mkSwalAttr "onRender" handler

    /// Function to run when modal closes by user interaction (and not by another popup), provides modal DOM element as the first argument.
    static member inline onClose (handler: HTMLElement -> unit) = Interop.mkSwalAttr "onClose" handler

    /// Function to run after popup has been disposed by user interaction (and not by another popup).
    static member inline onAfterClose (handler: unit -> unit) = Interop.mkSwalAttr "onAfterClose" handler

    /// Function to run after popup has been destroyed either by user interaction or by another popup.
    static member inline onDestroy (handler: unit -> unit) = Interop.mkSwalAttr "onDestroy" handler

[<Erase;RequireQualifiedAccess>]
module swal = 
    [<Erase>]
    type icon =
        static member inline success = Interop.mkSwalAttr "icon" "success"
        static member inline error = Interop.mkSwalAttr "icon" "error"
        static member inline warning = Interop.mkSwalAttr "icon" "warning"
        static member inline info = Interop.mkSwalAttr "icon" "info"
        static member inline question = Interop.mkSwalAttr "icon" "question"

    /// Multiple inputs aren't supported, you can achieve them by using html and preConfirm parameters.
    /// Inside the preConfirm() function you can return (or, if async, resolve with) the custom result.
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
        static member inline textArea = Interop.mkSwalAttr "input" "textarea"
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
