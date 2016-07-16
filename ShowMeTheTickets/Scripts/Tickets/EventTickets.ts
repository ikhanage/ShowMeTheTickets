/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />

module EventTickets{
    export function SetBindings() {
        //ko.cleanNode(document.getElementById('#TicketsContainer'));
        ko.applyBindingsToNode(document.getElementById('TicketsContainer'), new Bindings());
    }

    function Bindings() {
        this.MinTicketsToShow = ko.observable();
    }
}