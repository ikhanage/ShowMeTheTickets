/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />
var EventTickets;
(function (EventTickets) {
    function SetBindings() {
        //ko.cleanNode(document.getElementById('#TicketsContainer'));
        //ko.applyBindingsToNode(document.getElementById('TicketsContainer'), new Bindings());
    }
    EventTickets.SetBindings = SetBindings;
    function Bindings() {
        //this.MinTicketsToShow = ko.observable();
    }
})(EventTickets || (EventTickets = {}));
