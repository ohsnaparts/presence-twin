module DealingTest

open System
open CardGame.Cards
open Xunit

[<Fact>]
let ``Should return 51 cards when dealing a card from a new deck`` () =
    // Arrange
    let expected = 52 - 1
    let deck: Deck = newDeck
    // Act
    let (newDeck, _) = dealCard deck
    let actual = newDeck |> List.length
    // Assert
    Assert.Equal(expected, actual)

[<Fact>]
let ``Should return 0 cards when dealing a card from a depleted deck`` () =
    // Arrange
    let expected = 0
    // Act
    let newDeck,_ = dealCard []
    let actual = newDeck |> List.length
    // Assert
    Assert.Equal(expected, actual)

