namespace Feliz.SweetAlert

[<RequireQualifiedAccess>]
module Bindings =
    open Browser.Types
    open Fable.Core
    open Fable.Core.JsInterop

    type AlertResultBuilder() =
        member _.Bind(m, f) = Option.bind f m
        member _.Return(x) = Some x
        member _.ReturnFrom(x) = x
        member _.Zero() = None
        member _.Combine (a,b) = match a with | Some _ -> a | None -> b()
        member _.Delay(f) = f
        member _.Run(f) = f()

    let alertResult = new AlertResultBuilder()

    module Internal =
        type SweetAlertOptions = obj

        [<StringEnum; RequireQualifiedAccess>]
        type IDismissReason =
            | Backdrop
            | Cancel
            | Close
            | Esc
            | Timer

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

        let fireWrapper (input: JS.Promise<ISweetAlertResult>) =
            promise {
                let! result = input
                return
                    alertResult {
                        return! result.value |> Option.map (fun v -> ResultValue v)
                        let! dismissReason = result.dismiss
                        return
                            match dismissReason with
                            | IDismissReason.Backdrop -> DismissReason DismissReason.Backdrop
                            | IDismissReason.Cancel -> DismissReason DismissReason.Cancel
                            | IDismissReason.Close -> DismissReason DismissReason.Close
                            | IDismissReason.Esc -> DismissReason DismissReason.Esc
                            | IDismissReason.Timer -> DismissReason DismissReason.Timer
                    }
            }

    let swalInternal : obj = importDefault "sweetalert2"
    let withReactContent : obj -> Internal.SwalMethods = importDefault "sweetalert2-react-content"
    let swal = withReactContent(swalInternal)
    
    let getKV value : string * obj = unbox value
    let getKVV value : obj = getKV value |> snd
    let resultGet (res: Result<unit,string>) =
        match res with
        | Ok () -> None
        | Error e -> Some e

    let fireWrapper (handler: SweetAlertResult<'T> -> 'a) (input: JS.Promise<Internal.ISweetAlertResult>) dispatch =
        Promise.map (Option.iter (handler >> dispatch)) (Internal.fireWrapper input) 
        |> Promise.start

    let fireWrapperCmd (handler: SweetAlertResult<'T> -> 'Msg option) (input: JS.Promise<Internal.ISweetAlertResult>) dispatch =
        Promise.map (Option.iter (handler >> Option.iter dispatch)) (Internal.fireWrapper input)
        |> Promise.start

    let fireWrapperIgnore (dispatch: SweetAlertResult<'T> -> unit) (input: JS.Promise<Internal.ISweetAlertResult>) =
        fireWrapper id input dispatch

    let buildAlertResult (result: SweetAlertResult<'T>) =
        jsOptions<Internal.ISweetAlertResult> <| fun o ->
            match result with
            | ResultValue _ -> o.value <- Some o
            | DismissReason dr ->
                o.dismiss <- 
                    match dr with
                    | DismissReason.Backdrop -> Internal.IDismissReason.Backdrop
                    | DismissReason.Cancel -> Internal.IDismissReason.Cancel
                    | DismissReason.Close -> Internal.IDismissReason.Close
                    | DismissReason.Esc -> Internal.IDismissReason.Esc
                    | DismissReason.Timer -> Internal.IDismissReason.Timer
                    |> Some

    let elmishMsgHandler (result: 'Msg option) =
        match result with
        | Some msg -> Elmish.Cmd.ofMsg msg
        | None -> Elmish.Cmd.none
