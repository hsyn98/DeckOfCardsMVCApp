let cardCount = 52;
let currentCard = "";

initFunctionallity();

function initFunctionallity() {
    const startGameButton = $("#start-game-button");
    const dealACardButton = $("#deal-a-card");
    const cardCountButton = $("#cards-count");
    const shuffleButton = $("#shuffle");
    const restartGameButton = $("#restart-game");

    $(startGameButton).click(startGame)
    $(dealACardButton).click(dealACard);
    $(cardCountButton).click(cardsCount);
    $(shuffleButton).click(shuffle)
    $(restartGameButton).click(restartGame);
}

function startGame() {
    const startScreen = $("#start-screen");
    const gameScreen = $("#game-screen");

    $(startScreen).remove();
    $(gameScreen).removeClass("hidden");
}

function dealACard() {
    $.ajax({
        type: "GET",
        url: "/Home/DealOneCard",
    }).then(data => {
        if (data.card == null) {
            cardCount = 0;
            alert("No card left!")
        } else {
            $("#card").removeClass("hidden");

            cardCount = data.cardCount;
            currentCard = data.card;
            postMessage(`'${data.card}' is dealt`);
            placeCardImage();
        }
    }).catch(() => {
        alert("unknown error occurred!")
    })
}

function placeCardImage() {
    $("#card").css({
        backgroundImage: `url(${cards[currentCard]})`
    })
}

function cardsCount() {
    alert(cardCount + " card(s) left in the deck")
}

function shuffle() {
    if (cardCount > 1) {
        postMessage("Shuffling");

        $.ajax({
            type: "GET",
            url: "/Home/Shuffle",
        }).then(data => {
            postMessage("Cards are shuffled!");
        }).catch(() => {
            alert("unknown error occurred!")
        })
    } else {
        alert("Nothing to shuffle")
    }
}

function postMessage(messageText) {
    const message = $("#message");

    $(message).text(messageText);
}

function restartGame() {
    cardCount = 52;
    postMessage("");

    $.ajax({
        type: "GET",
        url: "/Home/Restart",
    }).then(data => {
        postMessage("Game restarted!");
    }).catch(() => {
        alert("unknown error occurred!")
    })

    $("#card").css({
        backgroundImage: ""
    }).addClass("hidden");
}