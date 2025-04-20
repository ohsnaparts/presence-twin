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

let allSuits = [ Hearts; Diamonds; Clubs; Spades ]

let allRanks =
    [ Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace ]

let deck =
    allSuits
    |> List.collect (fun suit -> allRanks |> List.map (fun rank -> Card(suit, rank)))
