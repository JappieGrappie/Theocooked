mergeInto(LibraryManager.library, {
    SendScoreToBrowser: function (score) {
        // Convert from C# int to JS number
        console.log("Score received from Unity: " + score);

        // Example: You could also dispatch a custom event
        var event = new CustomEvent('UnityScoreSent', { detail: { score: score } });
        window.dispatchEvent(event);

        // Or call a specific JS function if you have one:
        // window.receiveScore(score);
    }
});
	