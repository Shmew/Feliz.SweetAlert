namespace Feliz.SweetAlert

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open System.ComponentModel

[<EditorBrowsable(EditorBrowsableState.Never);Erase>]
module InternalTypes =
    type SweetAlertOptions = obj

    [<StringEnum; RequireQualifiedAccess>]
    type IDismissReason =
        | Backdrop
        | Cancel
        | Close
        | Esc
        | Timer

    [<AllowNullLiteral>]
    type ISweetAlertResult =
        abstract dismiss: IDismissReason option with get, set
        abstract isConfirmed: bool option with get, set
        abstract isDenied: bool option with get, set
        abstract isDismissed: bool option with get, set
        abstract value: 'T option with get, set

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
        /// Gets the popup header.
        abstract getHeader: unit -> HTMLElement
        /// Gets progress steps.
        abstract getProgressSteps: unit -> HTMLElement
        /// Gets the modal content.
        abstract getContent: unit -> HTMLElement
        /// Gets the DOM element where the html/text parameter is rendered to.
        abstract getHtmlContainer: unit -> HTMLElement
        /// Gets the image.
        abstract getImage: unit -> HTMLElement
        /// Gets the close button.
        abstract getCloseButton: unit -> HTMLElement option
        /// Gets the current visible icon.
        abstract getIcon: unit -> HTMLElement option
        /// Gets all icons. The current visible icon will have `style="display: flex"`,
        /// all other will be hidden by `style="display: none"`.
        abstract getIcons: unit -> ResizeArray<HTMLElement>
        /// Gets the "Confirm" button.
        abstract getConfirmButton: unit -> HTMLElement
        /// Gets the "Deny" button.
        abstract getDenyButton: unit -> HTMLElement
        /// Gets the "Cancel" button.
        abstract getCancelButton: unit -> HTMLElement
        /// Gets actions (buttons) wrapper.
        abstract getActions: unit -> HTMLElement
        /// Gets the modal footer.
        abstract getFooter: unit -> HTMLElement
        /// Gets the timer progress bar.
        abstract getTimerProgressBar: unit -> HTMLElement
        /// Gets all focusable elements in the popup.
        abstract getFocusableElements: unit -> ResizeArray<HTMLElement>
        /// Enables "Confirm" and "Cancel" buttons.
        abstract enableButtons: unit -> unit
        /// Disables "Confirm" and "Cancel" buttons.
        abstract disableButtons: unit -> unit
        /// Disables buttons and show loader. This is useful with AJAX requests.
        abstract showLoading: ?button: #HTMLElement -> unit
        /// Enables buttons and hide loader.
        abstract hideLoading: unit -> unit
        /// Determines if modal is in the loading state.
        abstract isLoading: unit -> bool
        /// Clicks the "Confirm"-button programmatically.
        abstract clickConfirm: unit -> unit
        /// Clicks the "Deny"-button programmatically.
        abstract clickDeny: unit -> unit
        /// Clicks the "Cancel"-button programmatically.
        abstract clickCancel: unit -> unit
        /// Shows a validation message
        /// The validation message.
        abstract showValidationMessage: validationMessage: string -> unit
        /// Hides validation message.
        abstract resetValidationMessage: unit -> unit
        /// Gets the input DOM node, this method works with input parameter.
        abstract getInput: unit -> HTMLInputElement option
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

[<EditorBrowsable(EditorBrowsableState.Never);RequireQualifiedAccess>]
module Bindings =
    open InternalTypes

    let swalInternal : obj = importDefault "sweetalert2"
    let withReactContent : obj -> SwalMethods = importDefault "sweetalert2-react-content"
    let swal = withReactContent(swalInternal)

//[<EditorBrowsable(EditorBrowsableState.Never);Erase;RequireQualifiedAccess>]
module Helpers =
    open InternalTypes

    let inline fireWrapperImpl (input: JS.Promise<ISweetAlertResult>) =
        promise {
            let! result = input

            return
                if result.isConfirmed = Some true then
                    result.value |> Option.map SweetAlert.Result.Value
                elif result.isDismissed = Some true then
                    match result.dismiss with
                    | Some rv ->
                        match rv with
                        | IDismissReason.Backdrop -> SweetAlert.Result.Dismissal DismissReason.Backdrop
                        | IDismissReason.Cancel -> SweetAlert.Result.Dismissal DismissReason.Cancel
                        | IDismissReason.Close -> SweetAlert.Result.Dismissal DismissReason.Close
                        | IDismissReason.Esc -> SweetAlert.Result.Dismissal DismissReason.Esc
                        | IDismissReason.Timer -> SweetAlert.Result.Dismissal DismissReason.Timer
                        |> Some
                    | None -> None
                elif result.isDenied = Some true then Some SweetAlert.Result.Denied
                else None
        }
    
    let inline getKV value : string * obj = unbox value
    let inline getKVV value : obj = getKV value |> snd
    let inline resultGet (res: Result<unit,string>) =
        match res with
        | Ok () -> None
        | Error e -> Some e

    let inline fireWrapper (handler: SweetAlert.Result<'T> -> 'a) (input: JS.Promise<ISweetAlertResult>) dispatch =
        Promise.map (Option.iter (handler >> dispatch)) (fireWrapperImpl input) 
        |> Promise.start

    let inline fireWrapperCmd (handler: SweetAlert.Result<'T> -> 'Msg option) (input: JS.Promise<ISweetAlertResult>) dispatch =
        Promise.map (Option.iter (handler >> Option.iter dispatch)) (fireWrapperImpl input)
        |> Promise.start

    let inline fireWrapperIgnore (dispatch: SweetAlert.Result<'T> -> unit) (input: JS.Promise<ISweetAlertResult>) =
        fireWrapper id input dispatch

    let inline dismissReasonToIDR (dr: DismissReason) =
        match dr with
        | DismissReason.Backdrop -> IDismissReason.Backdrop
        | DismissReason.Cancel -> IDismissReason.Cancel
        | DismissReason.Close -> IDismissReason.Close
        | DismissReason.Esc -> IDismissReason.Esc
        | DismissReason.Timer -> IDismissReason.Timer
        |> Some

    let inline buildAlertResult (result: SweetAlert.Result<'T>) =
        jsOptions<ISweetAlertResult> <| fun o ->
            match result with
            | SweetAlert.Result.Value v -> 
                o.value <- Some v
                o.isConfirmed <- Some true
                o.isDenied <- Some false
                o.isDismissed <- Some false
            | SweetAlert.Result.Denied ->
                o.value <- Some false
                o.isConfirmed <- Some false
                o.isDenied <- Some true
                o.isDismissed <- Some false
            | SweetAlert.Result.Dismissal dr ->
                o.value <- None
                o.isConfirmed <- Some false
                o.isDenied <- Some false
                o.isDismissed <- Some true
                o.dismiss <- dismissReasonToIDR dr

    let inline buildAlertResultUnit (result: SweetAlert.Result<unit>) =
        match result with
        | SweetAlert.Result.Value _ -> SweetAlert.Result.Value true 
        | _ -> unbox result
        |> buildAlertResult

    let inline elmishMsgHandler (result: 'Msg option) =
        match result with
        | Some msg -> Elmish.Cmd.ofMsg msg
        | None -> Elmish.Cmd.none
