using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardGame game = new CardGame();
            game.OpenMenu();
        }
    }

    class CardGame
    {
        private Deck _deck = new Deck();
        private Player _player = new Player();
        private bool _isClose = false;
        private int numberOfplayerCards;

        public void OpenMenu()
        {
            _deck.GenerateDeck();

            while (_isClose == false)
            {
                Console.Clear();
                Console.WriteLine("1 - взять карту, 2 - посмотреть свои карты, 3 - закончить игру");
                SelectCommand();
            }
        }

        private void SelectCommand()
        {
            char menuComand = Convert.ToChar(Console.ReadKey(true).Key);
            Console.Clear();

            switch (menuComand)
            {
                case '1':
                    DrawCard();
                    break;

                case '2':
                    LookAtTheCard();
                    break;

                case '3':
                    _isClose = true;
                    break;
            }
        }

        private void DrawCard()
        {
            numberOfplayerCards++;

            if (numberOfplayerCards <= _deck.MaxCardsInDeck)
            {
                _player.AddCard(_deck.RemoveCard());
            }
            else
            {
                Console.WriteLine("В колоде больше нету карт");
                Console.WriteLine("Нажмите любую кнопку...");
                Console.ReadKey(true);
            }
        }

        private void LookAtTheCard()
        {
            _player.ShowPlayerCards();
            _player.RemoveCards();
            Console.WriteLine("Нажмите любую кнопку...");
            Console.ReadKey(true);
        }
    }

    class Deck
    {
        private int _specificСardType = 0;
        private string _randomCard;
        private int _maxNumberOfSameType = 4;
        private Stack<Card> _cards = new Stack<Card>();
        private List<string> _cardsNames = new List<string>();
        private Dictionary<string, int> _deck = new Dictionary<string, int>()
        {
            {"Шестерка", 6},
            {"Семерка", 7},
            {"Весьмерка", 8},
            {"Девятка", 9},
            {"Десятка", 10},
            {"Валет", 2},
            {"Дама", 3},
            {"Король", 4},
            {"Туз", 11}
        };

        public int MaxCardsInDeck { get; private set; } = 36;

        public void AddCard(string name, int value)
        {
            _cards.Push(new Card(name, value));
        }

        public Card RemoveCard()
        {
            return _cards.Pop();
        }

        public void GenerateDeck()
        {
            Random random = new Random();
            while (_cards.Count() < MaxCardsInDeck)
            {
                int cardCounter = 0;

                foreach (var card in _deck)
                {

                    if (cardCounter == random.Next(0, 9))
                    {
                        _randomCard = card.Key;
                        _specificСardType = 0;

                        foreach (var elem in _cardsNames)
                        {
                            if (_randomCard == elem)
                            {
                                _specificСardType++;
                            }
                        }

                        if (_specificСardType < _maxNumberOfSameType)
                        {
                            _cards.Push(new Card(_randomCard, _deck[_randomCard]));
                            _cardsNames.Add(_randomCard);
                        }
                    }
                    cardCounter++;
                }
            }
        }
    }

    class Card
    {
        public string Name { get; private set; }

        public int CardValue { get; private set; }

        public Card(string name, int cardValue)
        {
            Name = name;
            CardValue = cardValue;
        }
    }

    class Player
    {
        private Card _card;
        private List<Card> _playerCards = new List<Card>();

        public void AddCard(Card card)
        {
            _playerCards.Add(card);
        }

        public void RemoveCards()
        {
            _playerCards.Clear();
        }

        public void ShowPlayerCards()
        {
            foreach (var card in _playerCards)
            {
                Console.WriteLine($"{card.Name}, {card.CardValue}");
            }
        }
    }
}