// rudimentary javascript logging to emulate console.log(). If there already exists
// an object named "console" (defined by most *useful* browsers :p) then we
// won't do anything here at all.
if (typeof (console) === 'undefined') {

    // define "console" namespace
    console = new function() {
        // this is the Id of the console div. It doesn't actually need to be a div,
        // as long as it has an innerHTML property.
        this.ConsoleDivId = "JavaScriptConsole";

        // maintains a reference to the console output div, so that we don't have to
        // call document.getElementById a bunch of times.
        this.ConsoleDiv = null;

        // allows us to cache whether or not the console div exists, so that we can
        // just do an early exit from the console.log method and similar if we're not
        // going to put any useful output anywhere.
        this.ConsoleDivExists = null;
    };

    // this is an expensive (really quite expensive) string padding function. Don't use
    // it for large strings.  -andrewh 11/3/09
    console.padString = function(s, padToLength, padCharacter) {
        var response = "" + s;
        while (response.length < padToLength) {
            response = padCharacter + response;
        }

        return response;
    }

    console.log = function(message) {

        // this will be executed once, on first method invocation, to get a reference to the
        // output div if it exists
        if (console.ConsoleDivExists == null) {
            console.ConsoleDiv = document.getElementById(console.ConsoleDivId);
            console.ConsoleDivExists = (console.ConsoleDiv != null);
        }

        // only do any logging if we actually have an output div.  (Check using the cached
        // variable so that we don't end up with a bunch of failed calls to
        // document.getElementById).
        if (console.ConsoleDivExists) {
            var date = new Date();
            var entireMessage =
                console.padString(date.getHours(), 2, "0") + ":" +
                console.padString(date.getMinutes(), 2, "0") + ":" +
                console.padString(date.getSeconds(), 2, "0") + "." +
                console.padString(date.getMilliseconds(), 3, "0") + " " + message;
            delete date;

            // append the message
            console.ConsoleDiv.innerHTML = console.ConsoleDiv.innerHTML + "<br />" + entireMessage;

            // scroll the div to the bottom
            console.ConsoleDiv.scrollTop = console.ConsoleDiv.scrollHeight;
        }
    }
}