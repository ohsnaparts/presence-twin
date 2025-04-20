module CardGame.Cards

type Suit =
    | Hearts
    | Diamonds
    | Clubs
    | Spades

type Rank =
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King
    | Ace

// do not reorder the tuple! Only append!
type Card = Card of Suit * Rank

type Deck = Card list

type Dealing = Deck * Card option

let allSuits = [ Hearts; Diamonds; Clubs; Spades ]

let allRanks =
    [ Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace ]

let newDeck =
    allSuits
    |> List.collect (fun suit -> allRanks |> List.map (fun rank -> Card(suit, rank)))


let dealCard (deck: Deck) : Dealing =
    let (restDeck, topCard) =
        match deck.Length with
        | 0 -> ([], None)
        | _ ->
            let topCard = Some deck.[0]
            let restDeck = deck |> List.skip 1
            (restDeck, topCard)
    restDeck, topCard
