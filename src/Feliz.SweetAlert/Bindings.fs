namespace Feliz.SweetAlert

[<RequireQualifiedAccess>]
module Bindings =
    open Browser.Types
    open Fable.Core
    open Fable.Core.JsInterop

    module Internal =
        type SweetAlertOptions = obj

        type IDismissReason =
            abstract backdrop: string option with get, set
            abstract cancel: string option with get, set
            abstract close: string option with get, set
            abstract esc: string option with get, set
            abstract timer: string option with get, set

        type [<AllowNullLiteral>] ISweetAlertResult =
            abstract value: 'T option with get, set
            abstract dismiss: IDismissReason option with get, set

        [<AllowNullLiteral>] 
        type SwalMethods =
            /// Function to display a simple SweetAlert2 modal.
            /// 
            /// ex.
            ///    import Swal from 'sweetalert2';
            ///    Swal.fire('The Internet?', 'That thing is still around?', 'question');
            abstract fire: ?title: string * ?message: string * ?icon: string -> JS.Promise<ISweetAlertResult>
            /// Function to display a SweetAlert2 modal, with an object of options, all being optional.
            /// See the SweetAlertOptions interface for the list of accepted fields and values.
            /// 
            /// ex.
            ///    import Swal from 'sweetalert2';
            ///    Swal.fire({
            ///      title: 'Auto close alert!',
            ///      text: 'I will close in 2 seconds.',
            ///      timer: 2000
            ///    })
            abstract fire: options: SweetAlertOptions -> JS.Promise<ISweetAlertResult>
            /// <summary>Reuse configuration by creating a Swal instance.</summary>
            /// <param name="options">the default options to set for this instance.</param>
            abstract ``mixin``: ?options: SweetAlertOptions -> obj
            /// Determines if a modal is shown.
            /// Be aware that the library returns a trueish or falsy value, not a real boolean.
            abstract isVisible: unit -> bool
            /// Updates popup options.
            /// See the SweetAlertOptions interface for the list of accepted fields and values.
            /// 
            /// ex.
            ///    swal.update({
            ///      icon: 'error'
            ///    })
            abstract update: options: SweetAlertOptions -> unit
            /// <summary>Closes the currently open SweetAlert2 modal programmatically.</summary>
            /// <param name="result">The promise originally returned by {</param>
            abstract close: ?result: ISweetAlertResult -> unit
            /// Gets the popup.
            abstract getPopup: unit -> HTMLElement
            /// Gets the modal title.
            abstract getTitle: unit -> HTMLElement
            /// Gets progress steps.
            abstract getProgressSteps: unit -> HTMLElement
            /// Gets the modal content.
            abstract getContent: unit -> HTMLElement
            /// Gets the DOM element where the html/text parameter is rendered to.
            abstract getHtmlContainer: unit -> HTMLElement
            /// Gets the image.
            abstract getImage: unit -> HTMLElement
            /// Gets the close button.
            abstract getCloseButton: unit -> HTMLElement
            /// Gets the current visible icon.
            abstract getIcon: unit -> HTMLElement option
            /// Gets all icons. The current visible icon will have `style="display: flex"`,
            /// all other will be hidden by `style="display: none"`.
            abstract getIcons: unit -> ResizeArray<HTMLElement>
            /// Gets the "Confirm" button.
            abstract getConfirmButton: unit -> HTMLElement
            /// Gets the "Cancel" button.
            abstract getCancelButton: unit -> HTMLElement
            /// Gets actions (buttons) wrapper.
            abstract getActions: unit -> HTMLElement
            /// Gets the modal footer.
            abstract getFooter: unit -> HTMLElement
            /// Gets all focusable elements in the popup.
            abstract getFocusableElements: unit -> ResizeArray<HTMLElement>
            /// Enables "Confirm" and "Cancel" buttons.
            abstract enableButtons: unit -> unit
            /// Disables "Confirm" and "Cancel" buttons.
            abstract disableButtons: unit -> unit
            /// Disables buttons and show loader. This is useful with AJAX requests.
            abstract showLoading: unit -> unit
            /// Enables buttons and hide loader.
            abstract hideLoading: unit -> unit
            /// Determines if modal is in the loading state.
            abstract isLoading: unit -> bool
            /// Clicks the "Confirm"-button programmatically.
            abstract clickConfirm: unit -> unit
            /// Clicks the "Cancel"-button programmatically.
            abstract clickCancel: unit -> unit
            /// <summary>Shows a validation message.</summary>
            /// <param name="validationMessage">The validation message.</param>
            abstract showValidationMessage: validationMessage: string -> unit
            /// Hides validation message.
            abstract resetValidationMessage: unit -> unit
            /// Gets the input DOM node, this method works with input parameter.
            abstract getInput: unit -> HTMLInputElement
            /// Disables the modal input. A disabled input element is unusable and un-clickable.
            abstract disableInput: unit -> unit
            /// Enables the modal input.
            abstract enableInput: unit -> unit
            /// Gets the validation message container.
            abstract getValidationMessage: unit -> HTMLElement
            /// If `timer` parameter is set, returns number of milliseconds of timer remained.
            /// Otherwise, returns undefined.
            abstract getTimerLeft: unit -> int option
            /// Stop timer. Returns number of milliseconds of timer remained.
            /// If `timer` parameter isn't set, returns undefined.
            abstract stopTimer: unit -> int option
            /// Resume timer. Returns number of milliseconds of timer remained.
            /// If `timer` parameter isn't set, returns undefined.
            abstract resumeTimer: unit -> int option
            /// Toggle timer. Returns number of milliseconds of timer remained.
            /// If `timer` parameter isn't set, returns undefined.
            abstract toggleTimer: unit -> int option
            /// Check if timer is running. Returns true if timer is running,
            /// and false is timer is paused / stopped.
            /// If `timer` parameter isn't set, returns undefined.
            abstract isTimerRunning: unit -> bool option
            /// <summary>Increase timer. Returns number of milliseconds of an updated timer.
            /// If `timer` parameter isn't set, returns undefined.</summary>
            /// <param name="n">The number of milliseconds to add to the currect timer</param>
            abstract increaseTimer: n: int -> int option
            /// <summary>Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.</summary>
            /// <param name="steps">The steps' configuration.</param>
            abstract queue: steps: ResizeArray<U2<SweetAlertOptions, string>> -> JS.Promise<ISweetAlertResult>
            /// Gets the index of current modal in queue. When there's no active queue, null will be returned.
            abstract getQueueStep: unit -> string option
            /// <summary>Inserts a modal in the queue.</summary>
            /// <param name="step">The step configuration (same object as in the Swal.fire() call).</param>
            /// <param name="index">The index to insert the step at.
            /// By default a modal will be added to the end of a queue.</param>
            abstract insertQueueStep: step: SweetAlertOptions * ?index: int -> int
            /// <summary>Deletes the modal at the specified index in the queue.</summary>
            /// <param name="index">The modal index in the queue.</param>
            abstract deleteQueueStep: index: int -> unit
            /// <summary>Determines if a given parameter name is valid.</summary>
            /// <param name="paramName">The parameter to check</param>
            abstract isValidParameter: paramName: string -> bool
            /// <summary>Determines if a given parameter name is valid for Swal.update() method.</summary>
            /// <param name="paramName">The parameter to check</param>
            abstract isUpdatableParameter: paramName: string -> bool
            abstract version: string

    let swalInternal : obj = importDefault "sweetalert2"
    let withReactContent : obj -> Internal.SwalMethods = importDefault "sweetalert2-react-content"
    let swal = withReactContent(swalInternal)
    //let fire (x: obj) : Promise<obj> = swal?fire(x)
    
    let getKV value : string * obj = unbox value
    let getKVV value : obj = getKV value |> snd
    let resultGet (res: Result<unit,string>) =
        match res with
        | Ok () -> None
        | Error e -> Some e

    type AlertResultBuilder() =
        member _.Bind(m, f) = Option.bind f m
        member _.Return(x) = Some x
        member _.ReturnFrom(x) = x
        member _.Zero() = None
        member _.Combine (a,b) = match a with | Some _ -> a | None -> b()
        member _.Delay(f) = f
        member _.Run(f) = f()

    let alertResult = new AlertResultBuilder()

    let fireWrapper (handler: SweetAlertResult<'T> -> 'a) (input: JS.Promise<Internal.ISweetAlertResult>) dispatch =
        promise {
            let! result = input
            alertResult {
                return! result.value |> Option.map (fun v -> ResultValue v)
                let! dismissReason = result.dismiss
                return! dismissReason.backdrop |> Option.map (fun _ -> DismissReason DismissReason.Backdrop)
                return! dismissReason.cancel |> Option.map (fun _ -> DismissReason DismissReason.Cancel)
                return! dismissReason.close |> Option.map (fun _ -> DismissReason DismissReason.Close)
                return! dismissReason.esc |> Option.map (fun _ -> DismissReason DismissReason.Esc)
                return! dismissReason.timer |> Option.map (fun _ -> DismissReason DismissReason.Timer)
            }
            |> (Option.get >> handler >> dispatch)
        } |> Promise.start

    let fireWrapperIgnore (dispatch: SweetAlertResult<'T> -> unit) (input: JS.Promise<Internal.ISweetAlertResult>) =
        fireWrapper id input dispatch

    let buildAlertResult (result: SweetAlertResult<'T>) =
        jsOptions<Internal.ISweetAlertResult> <| fun o ->
            match result with
            | ResultValue v -> o.value <- Some o
            | DismissReason dr ->
                o.dismiss <- 
                    Some (jsOptions<Internal.IDismissReason> <| fun d ->
                        match dr with
                        | DismissReason.Backdrop -> d.backdrop <- Some "backdrop"
                        | DismissReason.Cancel -> d.cancel <- Some "cancel"
                        | DismissReason.Close -> d.close <- Some "close"
                        | DismissReason.Esc -> d.esc <- Some "esc"
                        | DismissReason.Timer -> d.timer <- Some "timer")

    [<Emit("$0 == true")>]
    let isTruthy (input: obj) = jsNative

    
    

    //type [<StringEnum>] [<RequireQualifiedAccess>] SweetAlertIcon =
    //    | Success
    //    | Error
    //    | Warning
    //    | Info
    //    | Question


    //type [<AllowNullLiteral>] SweetAlertShowClass =
    //    abstract popup: string option with get, set
    //    abstract backdrop: string option with get, set
    //    abstract icon: string option with get, set

    //type [<AllowNullLiteral>] SweetAlertHideClass =
    //    abstract popup: string option with get, set
    //    abstract backdrop: string option with get, set
    //    abstract icon: string option with get, set

    //type [<AllowNullLiteral>] SweetAlertCustomClass =
    //    abstract container: string option with get, set
    //    abstract popup: string option with get, set
    //    abstract header: string option with get, set
    //    abstract title: string option with get, set
    //    abstract closeButton: string option with get, set
    //    abstract icon: string option with get, set
    //    abstract image: string option with get, set
    //    abstract content: string option with get, set
    //    abstract input: string option with get, set
    //    abstract actions: string option with get, set
    //    abstract confirmButton: string option with get, set
    //    abstract cancelButton: string option with get, set
    //    abstract footer: string option with get, set

    //type SyncOrAsync<'T> =
    //    U2<'T, Promise<'T>>

    //[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    //module SyncOrAsync =
    //    let ofT v: SyncOrAsync<'T> = v |> U2.Case1
    //    let isT (v: SyncOrAsync<'T>) = match v with U2.Case1 _ -> true | _ -> false
    //    let asT (v: SyncOrAsync<'T>) = match v with U2.Case1 o -> Some o | _ -> None
    //    let ofPromise v: SyncOrAsync<'T> = v |> U2.Case2
    //    let isPromise (v: SyncOrAsync<'T>) = match v with U2.Case2 _ -> true | _ -> false
    //    let asPromise (v: SyncOrAsync<'T>) = match v with U2.Case2 o -> Some o | _ -> None

    //type ValueOrThunk<'T> =
    //    U2<'T, (unit -> 'T)>

    //[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    //module ValueOrThunk =
    //    let ofT v: ValueOrThunk<'T> = v |> U2.Case1
    //    let isT (v: ValueOrThunk<'T>) = match v with U2.Case1 _ -> true | _ -> false
    //    let asT (v: ValueOrThunk<'T>) = match v with U2.Case1 o -> Some o | _ -> None
    //    let ofCase2 v: ValueOrThunk<'T> = v |> U2.Case2
    //    let isCase2 (v: ValueOrThunk<'T>) = match v with U2.Case2 _ -> true | _ -> false
    //    let asCase2 (v: ValueOrThunk<'T>) = match v with U2.Case2 o -> Some o | _ -> None

    //type SweetAlertArrayOptions =
    //    string * string * SweetAlertIcon

    //type [<AllowNullLiteral>] SweetAlertOptions =
    //    /// The title of the modal, as HTML.
    //    /// It can either be added to the object under the key "title" or passed as the first parameter of the function.
    //    abstract title: U2<string, HTMLElement> option with get, set
    //    /// The title of the modal, as text. Useful to avoid HTML injection.
    //    abstract titleText: string option with get, set
    //    /// A description for the modal.
    //    /// It can either be added to the object under the key "text" or passed as the second parameter of the function.
    //    abstract text: string option with get, set
    //    /// A HTML description for the modal.
    //    /// If "text" and "html" parameters are provided in the same time, "text" will be used.
    //    abstract html: U2<string, HTMLElement> option with get, set
    //    /// The footer of the modal, as HTML.
    //    abstract footer: U2<string, HTMLElement> option with get, set
    //    /// The icon of the modal.
    //    /// SweetAlert2 comes with 5 built-in icons which will show a corresponding icon animation: 'warning', 'error',
    //    /// 'success', 'info' and 'question'.
    //    /// It can either be put in the array under the key "icon" or passed as the third parameter of the function.
    //    abstract icon: SweetAlertIcon option with get, set
    //    /// The custom HTML content for an icon.
    //    /// 
    //    /// ex.
    //    ///    Swal.fire({
    //    ///      icon: 'error',
    //    ///      iconHtml: '<i class="fas fa-bug"></i>'
    //    ///    })
    //    abstract iconHtml: string option with get, set
    //    /// Whether or not SweetAlert2 should show a full screen click-to-dismiss backdrop.
    //    /// Either a boolean value or a css background value (hex, rgb, rgba, url, etc.)
    //    abstract backdrop: U2<bool, string> option with get, set
    //    /// Whether or not an alert should be treated as a toast notification.
    //    /// This option is normally coupled with the `position` parameter and a timer.
    //    /// Toasts are NEVER autofocused.
    //    abstract toast: bool option with get, set
    //    /// The container element for adding modal into (query selector only).
    //    abstract target: U2<string, HTMLElement> option with get, set
    //    /// Input field type, can be text, email, password, number, tel, range, textarea, select, radio, checkbox, file
    //    /// and url.
    //    abstract input: obj option with get, set
    //    /// Modal window width, including paddings (box-sizing: border-box). Can be in px or %.
    //    abstract width: U2<int, string> option with get, set
    //    /// Modal window padding.
    //    abstract padding: U2<int, string> option with get, set
    //    /// Modal window background (CSS background property).
    //    abstract background: string option with get, set
    //    /// Modal window position
    //    abstract position: obj option with get, set
    //    /// Modal window grow direction
    //    abstract grow: U4<string, string, string, obj> option with get, set
    //    /// CSS classes for animations when showing a popup (fade in)
    //    abstract showClass: SweetAlertShowClass option with get, set
    //    /// CSS classes for animations when hiding a popup (fade out)
    //    abstract hideClass: SweetAlertHideClass option with get, set
    //    /// A custom CSS class for the modal.
    //    /// If a string value is provided, the classname will be applied to the popup.
    //    /// If an object is provided, the classnames will be applied to the corresponding fields:
    //    /// 
    //    /// ex.
    //    ///    Swal.fire({
    //    ///      customClass: {
    //    ///        container: 'container-class',
    //    ///        popup: 'popup-class',
    //    ///        header: 'header-class',
    //    ///        title: 'title-class',
    //    ///        closeButton: 'close-button-class',
    //    ///        icon: 'icon-class',
    //    ///        image: 'image-class',
    //    ///        content: 'content-class',
    //    ///        input: 'input-class',
    //    ///        actions: 'actions-class',
    //    ///        confirmButton: 'confirm-button-class',
    //    ///        cancelButton: 'cancel-button-class',
    //    ///        footer: 'footer-class'
    //    ///      }
    //    ///    })
    //    abstract customClass: SweetAlertCustomClass option with get, set
    //    /// Auto close timer of the modal. Set in ms (milliseconds).
    //    abstract timer: int option with get, set
    //    /// If set to true, the timer will have a progress bar at the bottom of a popup.
    //    /// Mostly, this feature is useful with toasts.
    //    abstract timerProgressBar: bool option with get, set
    //    abstract animation: ValueOrThunk<bool> option with get, set
    //    /// By default, SweetAlert2 sets html's and body's CSS height to auto !important.
    //    /// If this behavior isn't compatible with your project's layout, set heightAuto to false.
    //    abstract heightAuto: bool option with get, set
    //    /// If set to false, the user can't dismiss the modal by clicking outside it.
    //    /// You can also pass a custom function returning a boolean value, e.g. if you want
    //    /// to disable outside clicks for the loading state of a modal.
    //    abstract allowOutsideClick: ValueOrThunk<bool> option with get, set
    //    /// If set to false, the user can't dismiss the modal by pressing the Escape key.
    //    /// You can also pass a custom function returning a boolean value, e.g. if you want
    //    /// to disable the escape key for the loading state of a modal.
    //    abstract allowEscapeKey: ValueOrThunk<bool> option with get, set
    //    /// If set to false, the user can't confirm the modal by pressing the Enter or Space keys,
    //    /// unless they manually focus the confirm button.
    //    /// You can also pass a custom function returning a boolean value.
    //    abstract allowEnterKey: ValueOrThunk<bool> option with get, set
    //    /// If set to false, SweetAlert2 will allow keydown events propagation to the document.
    //    abstract stopKeydownPropagation: bool option with get, set
    //    /// Useful for those who are using SweetAlert2 along with Bootstrap modals.
    //    /// By default keydownListenerCapture is false which means when a user hits Esc,
    //    /// both SweetAlert2 and Bootstrap modals will be closed.
    //    /// Set keydownListenerCapture to true to fix that behavior.
    //    abstract keydownListenerCapture: bool option with get, set
    //    /// If set to false, a "Confirm"-button will not be shown.
    //    /// It can be useful when you're using custom HTML description.
    //    abstract showConfirmButton: bool option with get, set
    //    /// If set to true, a "Cancel"-button will be shown, which the user can click on to dismiss the modal.
    //    abstract showCancelButton: bool option with get, set
    //    /// Use this to change the text on the "Confirm"-button.
    //    abstract confirmButtonText: string option with get, set
    //    /// Use this to change the text on the "Cancel"-button.
    //    abstract cancelButtonText: string option with get, set
    //    /// Use this to change the background color of the "Confirm"-button (must be a HEX value).
    //    abstract confirmButtonColor: string option with get, set
    //    /// Use this to change the background color of the "Cancel"-button (must be a HEX value).
    //    abstract cancelButtonColor: string option with get, set
    //    /// Use this to change the aria-label for the "Confirm"-button.
    //    abstract confirmButtonAriaLabel: string option with get, set
    //    /// Use this to change the aria-label for the "Cancel"-button.
    //    abstract cancelButtonAriaLabel: string option with get, set
    //    /// Whether to apply the default SweetAlert2 styling to buttons.
    //    /// If you want to use your own classes (e.g. Bootstrap classes) set this parameter to false.
    //    abstract buttonsStyling: bool option with get, set
    //    /// Set to true if you want to invert default buttons positions.
    //    abstract reverseButtons: bool option with get, set
    //    /// Set to false if you want to focus the first element in tab order instead of "Confirm"-button by default.
    //    abstract focusConfirm: bool option with get, set
    //    /// Set to true if you want to focus the "Cancel"-button by default.
    //    abstract focusCancel: bool option with get, set
    //    /// Set to true to show close button in top right corner of the modal.
    //    abstract showCloseButton: bool option with get, set
    //    /// Use this to change the content of the close button.
    //    abstract closeButtonHtml: string option with get, set
    //    /// Use this to change the `aria-label` for the close button.
    //    abstract closeButtonAriaLabel: string option with get, set
    //    /// Set to true to disable buttons and show that something is loading. Useful for AJAX requests.
    //    abstract showLoaderOnConfirm: bool option with get, set
    //    /// Function to execute before confirm, may be async (Promise-returning) or sync.
    //    /// 
    //    /// ex.
    //    ///    Swal.fire({
    //    ///     title: 'Multiple inputs',
    //    ///     html:
    //    ///       '<input id="swal-input1" class="swal2-input">' +
    //    ///       '<input id="swal-input2" class="swal2-input">',
    //    ///     focusConfirm: false,
    //    ///     preConfirm: () => [
    //    ///       document.querySelector('#swal-input1').value,
    //    ///       document.querySelector('#swal-input2').value
    //    ///     ]
    //    ///   }).then(result => Swal.fire(JSON.stringify(result));
    //    abstract preConfirm: inputValue: obj option -> SyncOrAsync<U2<obj option, unit>>
    //    /// Add a customized icon for the modal. Should contain a string with the path or URL to the image.
    //    abstract imageUrl: string option with get, set
    //    /// If imageUrl is set, you can specify imageWidth to describes image width in px.
    //    abstract imageWidth: int option with get, set
    //    /// If imageUrl is set, you can specify imageHeight to describes image height in px.
    //    abstract imageHeight: int option with get, set
    //    /// An alternative text for the custom image icon.
    //    abstract imageAlt: string option with get, set
    //    /// Input field placeholder.
    //    abstract inputPlaceholder: string option with get, set
    //    /// Input field initial value.
    //    abstract inputValue: SyncOrAsync<string> option with get, set
    //    /// If input parameter is set to "select" or "radio", you can provide options.
    //    /// Object keys will represent options values, object values will represent options text values.
    //    abstract inputOptions: SyncOrAsync<U2<Map<string, string>, TypeLiteral_01>> option with get, set
    //    /// Automatically remove whitespaces from both ends of a result string.
    //    /// Set this parameter to false to disable auto-trimming.
    //    abstract inputAutoTrim: bool option with get, set
    //    /// HTML input attributes (e.g. min, max, step, accept...), that are added to the input field.
    //    /// 
    //    /// ex.
    //    ///    Swal.fire({
    //    ///      title: 'Select a file',
    //    ///      input: 'file',
    //    ///      inputAttributes: {
    //    ///        accept: 'image/*'
    //    ///      }
    //    ///    })
    //    abstract inputAttributes: TypeLiteral_02 option with get, set
    //    /// Validator for input field, may be async (Promise-returning) or sync.
    //    /// 
    //    /// ex.
    //    ///    Swal.fire({
    //    ///      title: 'Select color',
    //    ///      input: 'radio',
    //    ///      inputValidator: result => !result && 'You need to select something!'
    //    ///    })
    //    abstract inputValidator: inputValue: string -> SyncOrAsync<string option>
    //    /// A custom validation message for default validators (email, url).
    //    /// 
    //    /// ex.
    //    ///    Swal.fire({
    //    ///      input: 'email',
    //    ///      validationMessage: 'Adresse e-mail invalide'
    //    ///    })
    //    abstract validationMessage: string option with get, set
    //    /// Progress steps, useful for modal queues, see usage example.
    //    abstract progressSteps: ResizeArray<string> option with get, set
    //    /// Current active progress step.
    //    abstract currentProgressStep: string option with get, set
    //    /// Distance between progress steps.
    //    abstract progressStepsDistance: string option with get, set
    //    /// Function to run when modal built, but not shown yet. Provides modal DOM element as the first argument.
    //    abstract onBeforeOpen: modalElement: HTMLElement -> unit
    //    /// Function to run when modal opens, provides modal DOM element as the first argument.
    //    abstract onOpen: modalElement: HTMLElement -> unit
    //    /// Function to run after modal DOM has been updated.
    //    /// Typically, this will happen after Swal.fire() or Swal.update().
    //    /// If you want to perform changes in the modal's DOM, that survive Swal.update(), onRender is a good place for that.
    //    abstract onRender: modalElement: HTMLElement -> unit
    //    /// Function to run when modal closes, provides modal DOM element as the first argument.
    //    abstract onClose: modalElement: HTMLElement -> unit
    //    /// Function to run after modal has been disposed.
    //    abstract onAfterClose: unit -> unit
    //    /// Set to false to disable body padding adjustment when scrollbar is present.
    //    abstract scrollbarPadding: bool option with get, set

    //type [<AllowNullLiteral>] TypeLiteral_02 =
    //    [<Emit "$0[$1]{{=$2}}">] abstract Item: attribute: string -> string with get, set

    //type [<AllowNullLiteral>] TypeLiteral_01 =
    //    [<Emit "$0[$1]{{=$2}}">] abstract Item: inputValue: string -> string with get, set
