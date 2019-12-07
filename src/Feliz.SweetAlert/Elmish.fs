namespace Feliz.SweetAlert

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop

module Cmd =
    open Elmish

    [<Erase>]
    type Swal =
        /// Function to display a SweetAlert2 modal.
        static member inline fire (options: ISwalProperty list) : Cmd<_> = 
            [ fun _ -> Bindings.swal.fire (createObj !!options) |> Promise.start ]

        /// Function to display a SweetAlert2 modal.
        static member inline fire (options: ISwalProperty list, handler: (SweetAlertResult<'T> -> 'Msg option)) : Cmd<_> = 
            [ Bindings.swal.fire (createObj !!options) |> Bindings.fireWrapperCmd handler ]

        /// Determine if modal is shown.
        static member inline isVisible() : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.isVisible() |> dispatch ]

        /// Updates popup options.
        static member inline update (options: ISwalProperty list) : Cmd<_> =
            [ fun _ -> Bindings.swal.update (createObj !!options) ]

        /// Close the currently open SweetAlert2 modal programmatically, the Promise returned by Swal.fire() will be resolved with an empty object { } if no value is provided.
        static member inline close () : Cmd<_> = [ fun _ -> Bindings.swal.close() ]

        /// Close the currently open SweetAlert2 modal programmatically, the Promise returned by Swal.fire() will be resolved with an empty object { } if no value is provided.
        static member inline close (result: SweetAlertResult<'T>) : Cmd<_> = 
            [ fun _ -> Bindings.swal.close (result |> Bindings.buildAlertResult) ]
        
        /// Gets the popup.
        static member inline getPopup (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getPopup() |> handler |> dispatch ]

        /// Gets the modal title.
        static member inline getTitle (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getTitle() |> handler |> dispatch ]

        /// Gets progress steps.
        static member inline getProgressSteps (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getProgressSteps() |> handler |> dispatch ]

        /// Gets the modal content.
        static member inline getContent (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getContent() |> handler |> dispatch ]
        
        /// Gets the DOM element where the html/text parameter is rendered to.
        static member inline getHtmlContainer (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getHtmlContainer() |> handler |> dispatch ]

        /// Gets the image.
        static member inline getImage (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getImage() |> handler |> dispatch ]

        /// Gets the close button.
        static member inline getCloseButton (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch ->  Bindings.swal.getCloseButton() |> handler |> dispatch ]

        /// Gets the current visible icon.
        static member inline getIcon (handler: HTMLElement option -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getIcon() |> handler |> dispatch ]

        /// Gets all icons. The current visible icon will have `style="display: flex"`,
        /// all other will be hidden by `style="display: none"`.
        static member inline getIcons (handler: HTMLElement list -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getIcons() |> List.ofSeq |> handler |> dispatch ]

        /// Gets the "Confirm" button.
        static member inline getConfirmButton (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getConfirmButton() |> handler |> dispatch ]

        /// Gets the "Cancel" button.
        static member inline getCancelButton (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getCancelButton() |> handler |> dispatch ]

        /// Gets actions (buttons) wrapper.
        static member inline getActions (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getActions() |> handler |> dispatch ]

        /// Gets the modal footer.
        static member inline getFooter (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getFooter() |> handler |> dispatch ]

        /// Gets all focusable elements in the popup.
        static member inline getFocusableElements (handler: HTMLElement list -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getFocusableElements() |> List.ofSeq |> handler |> dispatch ]

        /// Enables "Confirm" and "Cancel" buttons.
        static member inline enableButtons() : Cmd<_> = [ fun _ -> Bindings.swal.enableButtons() ]

        /// Disables "Confirm" and "Cancel" buttons.
        static member inline disableButtons() : Cmd<_> = [ fun _ -> Bindings.swal.disableButtons() ]

        /// Disables buttons and show loader. This is useful with AJAX requests.
        static member inline showLoading() : Cmd<_> = [ fun _ -> Bindings.swal.showLoading() ]

        /// Enables buttons and hide loader.
        static member inline hideLoading() : Cmd<_> = [ fun _ -> Bindings.swal.hideLoading() ]

        /// Determines if modal is in the loading state.
        static member inline isLoading (handler: bool -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.isLoading() |> handler |> dispatch ]

        /// Clicks the "Confirm"-button programmatically.
        static member inline clickConfirm() : Cmd<_> = [ fun _ -> Bindings.swal.clickConfirm() ]

        /// Clicks the "Cancel"-button programmatically.
        static member inline clickCancel() : Cmd<_> = [ fun _ -> Bindings.swal.clickCancel() ]

        /// Shows a validation message.
        static member inline showValidationMessage (message: string) : Cmd<_> = 
            [ fun _ -> Bindings.swal.showValidationMessage message ]

        /// Hides validation message.
        static member inline resetValidationMessage() : Cmd<_> = [ fun _ -> Bindings.swal.resetValidationMessage() ]

        /// Gets the input DOM node, this method works with input parameter.
        static member inline getInput (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getInput() |> handler |> dispatch ]

        /// Disables the modal input. A disabled input element is unusable and un-clickable.
        static member inline disableInput() : Cmd<_> = [ fun _ -> Bindings.swal.disableInput() ]

        /// Enables the modal input.
        static member inline enableInput() : Cmd<_> = [ fun _ -> Bindings.swal.enableInput() ]

        /// Gets the validation message container.
        static member inline getValidationMessage (handler: HTMLElement -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getValidationMessage() |> handler |> dispatch ]

        /// If `timer` parameter is set, returns number of milliseconds of timer remained.
        /// Otherwise, returns None.
        static member inline getTimerLeft (handler: int option -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getTimerLeft() |> handler |> dispatch ]

        /// Stop timer. Returns number of milliseconds of timer remained.
        /// If `timer` parameter isn't set, returns None.
        static member inline stopTimer (handler: int option -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.stopTimer() |> handler |> dispatch ]

        /// Resume timer. Returns number of milliseconds of timer remained.
        /// If `timer` parameter isn't set, returns None.
        static member inline resumeTimer (handler: int option -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.resumeTimer() |> handler |> dispatch ]

        /// Toggle timer. Returns number of milliseconds of timer remained.
        /// If `timer` parameter isn't set, returns None.
        static member inline toggleTimer (handler: int option -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.toggleTimer() |> handler |> dispatch ]

        /// Check if timer is running. Returns true if timer is running,
        /// and false is timer is paused / stopped.
        /// If `timer` parameter isn't set, returns None.
        static member inline isTimerRunning (handler: bool option -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.isTimerRunning() |> handler |> dispatch ]

        /// Increase timer. Returns number of milliseconds of an updated timer.
        /// If `timer` parameter isn't set, returns None.
        static member inline increaseTimer (ms: int, handler: int option -> 'Msg option) : Cmd<_> =
            [ fun dispatch -> Bindings.swal.increaseTimer ms |> handler |> dispatch ]

        /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
        static member inline queue (steps: ISwalProperty list) : Cmd<_> = 
            fun _ ->
                [ steps ]
                |> List.map (fun props -> (createObj !!props) |> U2.Case1) 
                |> ResizeArray 
                |> Bindings.swal.queue 
                |> Promise.start
            |> List.singleton

        /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
        static member inline queue (steps: ISwalProperty list list) : Cmd<_> = 
            fun _ ->
                steps 
                |> List.map (fun props -> (createObj !!props) |> U2.Case1) 
                |> ResizeArray 
                |> Bindings.swal.queue 
                |> Promise.start
            |> List.singleton

        /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
        static member inline queue (steps: ISwalProperty list list, handler: (SweetAlertResult<'T> -> 'Msg option)) : Cmd<_> = 
            steps 
            |> List.map (fun props -> (createObj !!props) |> U2.Case1) 
            |> ResizeArray 
            |> Bindings.swal.queue 
            |> Bindings.fireWrapperCmd handler
            |> List.singleton

        /// Gets the index of current modal in queue. When there's no active queue, None will be returned.
        static member inline getQueueStep (handler: string option -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.getQueueStep() |> handler |> dispatch ]

        /// Inserts a modal in the queue.
        static member inline insertQueueStep (step: ISwalProperty list, handler: int -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.insertQueueStep (createObj !!step) |> handler |> dispatch ]

        /// Inserts a modal in the queue.
        static member inline insertQueueStep (step: ISwalProperty list, index: int, handler: int -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.insertQueueStep ((createObj !!step), index) |> handler |> dispatch ]

        /// Deletes the modal at the specified index in the queue.
        static member inline deleteQueueStep (index: int) : Cmd<_> = [ fun _ -> Bindings.swal.deleteQueueStep index ]

        /// Determines if a given parameter name is valid.
        static member inline isValidParameter (paramName: string, handler: bool -> 'Msg option) : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.isValidParameter paramName |> handler |> dispatch ]

        /// Determines if a given parameter name is valid for Swal.update() method.
        static member inline isUpdatableParameter (paramName: string, handler: bool -> 'Msg option)  : Cmd<_> = 
            [ fun dispatch -> Bindings.swal.isUpdatableParameter paramName |> handler |> dispatch ]

        /// SweetAlert2's version
        static member inline version (handler: string -> 'Msg option) = 
            [ fun dispatch -> Bindings.swal.version |> handler |> dispatch ]
    
    module Swal =
        [<Erase>]
        type Simple =
            static member inline basic (message: string) : Cmd<_> =
                [ fun _ -> Swal.Simple.basic(message) ]

            static member inline basic (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.basic(title, message) ]

            static member inline basic (title: string, message: string, handler: (SweetAlertResult<'T> -> 'Msg option)) : Cmd<_> = 
                Swal.fire([ swal.title title; swal.text message ], handler)

            static member inline error (message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.error(message) ]

            static member inline error (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.error(title, message) ]

            static member inline error (title: string, message: string, handler: (SweetAlertResult<'T> -> 'Msg option)) : Cmd<_> = 
                Swal.fire([ swal.title title; swal.text message; swal.icon.error ], handler)
    
            static member inline info (message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.info(message) ]

            static member inline info (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.info(title, message) ]

            static member inline info (title: string, message: string, handler: (SweetAlertResult<'T> -> 'Msg option)) : Cmd<_> = 
                Swal.fire([ swal.title title; swal.text message; swal.icon.info ], handler)
    
            static member inline question (message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.question(message) ]

            static member inline question (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.question(title, message) ]

            static member inline question (title: string, message: string, handler: (SweetAlertResult<'T> -> 'Msg option)) : Cmd<_> = 
                Swal.fire([ swal.title title; swal.text message; swal.icon.question ], handler)
    
            static member inline success (message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.success(message) ]

            static member inline success (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.success(title, message) ]

            static member inline success (title: string, message: string, handler: (SweetAlertResult<'T> -> 'Msg option)) : Cmd<_> = 
                Swal.fire([ swal.title title; swal.text message; swal.icon.success ], handler)
    
            static member inline warning (message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.warning(message) ]

            static member inline warning (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Swal.Simple.warning(title, message) ]

            static member inline warning (title: string, message: string, handler: (SweetAlertResult<'T> -> 'Msg option)) : Cmd<_> = 
                Swal.fire([ swal.title title; swal.text message; swal.icon.warning ], handler)
