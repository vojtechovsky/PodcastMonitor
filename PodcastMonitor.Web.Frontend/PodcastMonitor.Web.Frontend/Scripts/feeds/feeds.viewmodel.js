// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
function AppViewModel() {
    this.feedName = ko.observable("Bert");
    this.feedSetName = ko.observable("Bertington");
    this.fullName = ko.computed(function () {
        return this.feedName() + ' ' + this.feedSetName();
    }, this);
    
    this.capitalizeLastName = function () {
        var currentVal = this.feedSetName();        // Read the current value
        this.feedSetName(currentVal.toUpperCase()); // Write back a modified value
    };
}

// Activates knockout.js
ko.applyBindings(new AppViewModel());