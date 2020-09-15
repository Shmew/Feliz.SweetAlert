namespace Feliz.SweetAlert

open Fable.Core
open Fable.Core.JsInterop
open System.ComponentModel

[<Erase>]
type Swal =
    /// Function to display a SweetAlert2 modal.
    static member inline fire (options: #ISwalProperty list) = 
        Bindings.swal.fire (createObj !!options) |> Promise.start

    /// Function to display a SweetAlert2 modal.
    static member inline fire (options: #ISwalProperty list, handler: (SweetAlert.Result<'T> -> unit)) = 
        Bindings.swal.fire (createObj !!options) |> Helpers.fireWrapperIgnore handler

    /// Determine if modal is shown.
    static member inline isVisible () = Bindings.swal.isVisible()

    /// Updates popup options.
    static member inline update (options: ISwalUpdatableProperty list) = Bindings.swal.update (createObj !!options)

    /// Close the currently open SweetAlert2 modal programmatically, the Promise returned by Swal.fire () will be resolved with an empty object { } if no value is provided.
    static member inline close () = Bindings.swal.close()

    /// Close the currently open SweetAlert2 modal programmatically, the Promise returned by Swal.fire () will be resolved with an empty object { } if no value is provided.
    static member inline close (result: SweetAlert.Result<'T>) = Bindings.swal.close (result |> Helpers.buildAlertResult)

    /// Gets the popup.
    static member inline getPopup () = Bindings.swal.getPopup()

    /// Gets the modal title.
    static member inline getTitle () = Bindings.swal.getTitle()

    /// Gets progress steps.
    static member inline getProgressSteps () = Bindings.swal.getProgressSteps()

    /// Gets the modal content.
    static member inline getContent () = Bindings.swal.getContent()

    /// Gets the DOM element where the html/text parameter is rendered to.
    static member inline getHtmlContainer () = Bindings.swal.getHtmlContainer()

    /// Gets the image.
    static member inline getImage () = Bindings.swal.getImage()

    /// Gets the close button.
    static member inline getCloseButton () = Bindings.swal.getCloseButton()

    /// Gets the current visible icon.
    static member inline getIcon () = Bindings.swal.getIcon()

    /// Gets all icons. The current visible icon will have `style="display: flex"`,
    /// all other will be hidden by `style="display: none"`.
    static member inline getIcons () = Bindings.swal.getIcons()

    /// Gets the "Confirm" button.
    static member inline getConfirmButton () = Bindings.swal.getConfirmButton()

    /// Gets the "Deny" button.
    static member inline getDenyButton () = Bindings.swal.getDenyButton()

    /// Gets the "Cancel" button.
    static member inline getCancelButton () = Bindings.swal.getCancelButton()

    /// Gets actions (buttons) wrapper.
    static member inline getActions () = Bindings.swal.getActions()

    /// Gets the modal footer.
    static member inline getFooter () = Bindings.swal.getFooter()

    /// Gets the timer progress bar.
    static member inline getTimerProgressBar () = Bindings.swal.getTimerProgressBar()

    /// Gets all focusable elements in the popup.
    static member inline getFocusableElements () = Bindings.swal.getFocusableElements()

    /// Enables "Confirm" and "Cancel" buttons.
    static member inline enableButtons () = Bindings.swal.enableButtons()

    /// Disables "Confirm" and "Cancel" buttons.
    static member inline disableButtons () = Bindings.swal.disableButtons()

    /// Disables buttons and show loader. This is useful with AJAX requests.
    static member inline showLoading () = Bindings.swal.showLoading()

    /// Enables buttons and hide loader.
    static member inline hideLoading () = Bindings.swal.hideLoading()

    /// Determines if modal is in the loading state.
    static member inline isLoading () = Bindings.swal.isLoading()

    /// Clicks the "Confirm"-button programmatically.
    static member inline clickConfirm () = Bindings.swal.clickConfirm()

    /// Clicks the "Deny"-button programmatically.
    static member inline clickDeny () = Bindings.swal.clickDeny()

    /// Clicks the "Cancel"-button programmatically.
    static member inline clickCancel () = Bindings.swal.clickCancel()

    /// Shows a validation message.
    static member inline showValidationMessage (message: string) = Bindings.swal.showValidationMessage message

    /// Hides validation message.
    static member inline resetValidationMessage () = Bindings.swal.resetValidationMessage()

    /// Gets the input DOM node, this method works with input parameter.
    static member inline getInput () = Bindings.swal.getInput()

    /// Disables the modal input. A disabled input element is unusable and un-clickable.
    static member inline disableInput () = Bindings.swal.disableInput()

    /// Enables the modal input.
    static member inline enableInput () = Bindings.swal.enableInput()

    /// Gets the validation message container.
    static member inline getValidationMessage () = Bindings.swal.getValidationMessage()

    /// If `timer` parameter is set, returns number of milliseconds of timer remained.
    /// Otherwise, returns None.
    static member inline getTimerLeft () = Bindings.swal.getTimerLeft()

    /// Stop timer. Returns number of milliseconds of timer remained.
    /// If `timer` parameter isn't set, returns None.
    static member inline stopTimer () = Bindings.swal.stopTimer()

    /// Resume timer. Returns number of milliseconds of timer remained.
    /// If `timer` parameter isn't set, returns None.
    static member inline resumeTimer () = Bindings.swal.resumeTimer()

    /// Toggle timer. Returns number of milliseconds of timer remained.
    /// If `timer` parameter isn't set, returns None.
    static member inline toggleTimer () = Bindings.swal.toggleTimer()

    /// Check if timer is running. Returns true if timer is running,
    /// and false is timer is paused / stopped.
    /// If `timer` parameter isn't set, returns None.
    static member inline isTimerRunning () = Bindings.swal.isTimerRunning()

    /// Increase timer. Returns number of milliseconds of an updated timer.
    /// If `timer` parameter isn't set, returns None.
    static member inline increaseTimer (ms: int) = Bindings.swal.increaseTimer ms

    /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
    static member inline queue (steps: ISwalProperty list) = 
        [ steps ]
        |> List.map (fun props -> (createObj !!props) |> U2.Case1) 
        |> ResizeArray 
        |> Bindings.swal.queue 
        |> Promise.start

    /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
    static member inline queue (steps: ISwalProperty list, handler: (SweetAlert.Result<'T> -> unit)) = 
        [ steps ]
        |> List.map (fun props -> (createObj !!props) |> U2.Case1) 
        |> ResizeArray 
        |> Bindings.swal.queue 
        |> Helpers.fireWrapperIgnore handler

    /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
    static member inline queue (steps: ISwalProperty list list) = 
        steps 
        |> List.map (fun props -> (createObj !!props) |> U2.Case1) 
        |> ResizeArray 
        |> Bindings.swal.queue 
        |> Promise.start

    /// Provide an array of SweetAlert2 parameters to show multiple modals, one modal after another.
    static member inline queue (steps: ISwalProperty list list, handler: (SweetAlert.Result<'T> -> unit)) = 
        steps 
        |> List.map (fun props -> (createObj !!props) |> U2.Case1) 
        |> ResizeArray 
        |> Bindings.swal.queue 
        |> Helpers.fireWrapperIgnore handler

    /// Gets the index of current modal in queue. When there's no active queue, None will be returned.
    static member inline getQueueStep () = Bindings.swal.getQueueStep()

    /// Inserts a modal in the queue.
    static member inline insertQueueStep (step: ISwalProperty list) = Bindings.swal.insertQueueStep (createObj !!step)

    /// Inserts a modal in the queue.
    static member inline insertQueueStep (step: ISwalProperty list, index: int) = Bindings.swal.insertQueueStep ((createObj !!step), index)

    /// Deletes the modal at the specified index in the queue.
    static member inline deleteQueueStep (index: int) = Bindings.swal.deleteQueueStep index

    /// Determines if a given parameter name is valid.
    static member inline isValidParameter (paramName: string) = Bindings.swal.isValidParameter paramName

    /// Determines if a given parameter name is valid for Swal.update() method.
    static member inline isUpdatableParameter (paramName: string) = Bindings.swal.isUpdatableParameter paramName

    /// SweetAlert2's version
    static member inline version () = Bindings.swal.version

[<Erase;RequireQualifiedAccess>]
module Swal =
    [<Erase>]
    type Simple =
        static member inline basic (message: string) =
            Swal.fire [ swal.text message ]

        static member inline basic (title: string, message: string) = 
            Swal.fire [ swal.title title; swal.text message ]

        static member inline basic (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
            Swal.fire ([ swal.title title; swal.text message ], handler)

        static member inline error (message: string) = 
            Swal.fire [ swal.text message; swal.icon.error ]

        static member inline error (title: string, message: string) = 
            Swal.fire [ swal.title title; swal.text message; swal.icon.error ]
        
        static member inline error (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
            Swal.fire ([ swal.title title; swal.text message; swal.icon.error ], handler)

        static member inline info (message: string) = 
            Swal.fire [ swal.text message; swal.icon.info ] 

        static member inline info (title: string, message: string) = 
            Swal.fire [ swal.title title; swal.text message; swal.icon.info ] 
        
        static member inline info (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
            Swal.fire ([ swal.title title; swal.text message; swal.icon.info ], handler)

        static member inline question (message: string) = 
            Swal.fire [ swal.text message; swal.icon.question ]

        static member inline question (title: string, message: string) = 
            Swal.fire [ swal.title title; swal.text message; swal.icon.question ]
        
        static member inline question (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
            Swal.fire ([ swal.title title; swal.text message; swal.icon.question ], handler)

        static member inline success (message: string) = 
            Swal.fire [ swal.text message; swal.icon.success ]

        static member inline success (title: string, message: string) = 
            Swal.fire [ swal.title title; swal.text message; swal.icon.success ]
        
        static member inline success (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
            Swal.fire ([ swal.title title; swal.text message; swal.icon.success ], handler)

        static member inline warning (message: string) = 
            Swal.fire [ swal.text message; swal.icon.warning ]

        static member inline warning (title: string, message: string) = 
            Swal.fire [ swal.title title; swal.text message; swal.icon.warning ]
        
        static member inline warning (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
            Swal.fire ([ swal.title title; swal.text message; swal.icon.warning ], handler)

    [<Erase>]
    module Simple =
        [<Erase>]
        type Deny =
            static member inline basic (message: string) =
                Swal.fire [ swal.text message; swal.showDenyButton true ]

            static member inline basic (title: string, message: string) = 
                Swal.fire [ swal.title title; swal.text message; swal.showDenyButton true ]

            static member inline basic (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
                Swal.fire ([ swal.title title; swal.text message; swal.showDenyButton true ], handler)

            static member inline error (message: string) = 
                Swal.fire [ swal.text message; swal.icon.error; swal.showDenyButton true ]

            static member inline error (title: string, message: string) = 
                Swal.fire [ swal.title title; swal.text message; swal.icon.error; swal.showDenyButton true ]
        
            static member inline error (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
                Swal.fire ([ swal.title title; swal.text message; swal.icon.error; swal.showDenyButton true ], handler)

            static member inline info (message: string) = 
                Swal.fire [ swal.text message; swal.icon.info; swal.showDenyButton true ] 

            static member inline info (title: string, message: string) = 
                Swal.fire [ swal.title title; swal.text message; swal.icon.info; swal.showDenyButton true ] 
        
            static member inline info (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
                Swal.fire ([ swal.title title; swal.text message; swal.icon.info; swal.showDenyButton true ], handler)

            static member inline question (message: string) = 
                Swal.fire [ swal.text message; swal.icon.question; swal.showDenyButton true ]

            static member inline question (title: string, message: string) = 
                Swal.fire [ swal.title title; swal.text message; swal.icon.question; swal.showDenyButton true ]
        
            static member inline question (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
                Swal.fire ([ swal.title title; swal.text message; swal.icon.question; swal.showDenyButton true ], handler)

            static member inline success (message: string) = 
                Swal.fire [ swal.text message; swal.icon.success; swal.showDenyButton true ]

            static member inline success (title: string, message: string) = 
                Swal.fire [ swal.title title; swal.text message; swal.icon.success; swal.showDenyButton true ]
        
            static member inline success (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
                Swal.fire ([ swal.title title; swal.text message; swal.icon.success; swal.showDenyButton true ], handler)

            static member inline warning (message: string) = 
                Swal.fire [ swal.text message; swal.icon.warning; swal.showDenyButton true ]

            static member inline warning (title: string, message: string) = 
                Swal.fire [ swal.title title; swal.text message; swal.icon.warning; swal.showDenyButton true ]
        
            static member inline warning (title: string, message: string, handler: (SweetAlert.Result<'T> -> unit)) = 
                Swal.fire ([ swal.title title; swal.text message; swal.icon.warning; swal.showDenyButton true ], handler)
