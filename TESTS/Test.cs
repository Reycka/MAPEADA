﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Game;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace TESTS
{
    [TestFixture]
    public class TestBoard
    {
        /// <summary>
        /// TESTS DEL TABLERO
        /// </summary>
       /* [Test]
        public void board()
        {
            
        }*/

        [Test]
        public void IsWallAtOutofLimits ()
        {
            //Arrange
            Board board = new Board(3,3,"00g" + "0w0" + "000",3);
            //Act
            bool isWall = board.IsWallAt(-1, 1);
            //Assert
            ClassicAssert.IsFalse(isWall, "Fuera de rango");
        }

        [Test]
        public void IsWall()
        {
            //Arrange
            Board board = new Board(3, 3, "00g" + "0w0" + "000", 3);
            //Act
            bool isWall = board.IsWallAt(1, 1);
            //Assert
            ClassicAssert.IsTrue(isWall, "Hay muro");
        }
        [Test]
        public void IsntWall()
        {
            //Arrange
            Board board = new Board(3, 3, "00g" + "0w0" + "000", 3);
            //Act
            bool isWall = board.IsWallAt(0, 0);
            //Assert
            ClassicAssert.IsFalse(isWall, "No hay muro");
        }
        [Test]
        public void IsGoalAtOutofLimits()
        {
            //Arrange
            Board board = new Board(3, 3, "00g" + "0w0" + "000", 3);
            //Act
            bool isGoal = board.IsGoalAt(-1, 1);
            //Assert
            ClassicAssert.IsFalse(isGoal, "Fuera de rango");
        }

        [Test]
        public void IsGoal()
        {
            //Arrange
            Board board = new Board(3, 3, "00g" + "0w0" + "000", 3);
            //Act
            bool isGoal = board.IsGoalAt(0, 2);
            //Assert
            ClassicAssert.IsTrue(isGoal, "Hay goal");
        }
        [Test]
        public void IsntGoal()
        {
            //Arrange
            Board board = new Board(3, 3, "00g" + "0w0" + "000", 3);
            //Act
            bool isGoal = board.IsGoalAt(0, 0);
            //Assert
            ClassicAssert.IsFalse(isGoal, "No hay goal");
        }
        [Test]
        public void IsItemAtOutOfRange()
        {
            //Arrange
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 3);
            //Act
            bool isWall = board.ContainsItem(-1, 1);
            //Assert
            ClassicAssert.IsFalse(isWall, "Fuera de rango");
        }
        [Test]
        public void IsItem()
        {
            //Arrange
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 3);
            //Act
            bool isItem = board.ContainsItem(0,2);
            //Assert
            ClassicAssert.IsTrue(isItem, "Es objeto");
        }
        [Test]
        public void IsntItem()
        {
            //Arrange
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 3);
            //Act
            bool isItem = board.ContainsItem(1, 1);
            //Assert
            ClassicAssert.IsFalse(isItem, "No es objeto");
        }
        [Test]
        public void AddItem()
        {
            //Arrange
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 3);
            //Act
            bool add = board.AddItem(0, 2,69);
            //Assert
            ClassicAssert.IsTrue(add, "Hay que añadir");
        }
        [Test]
        public void AddntItem()
        {
            //Arrange
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 3);
            //Act
            bool addnt = board.AddItem(0, 1, 69);
            //Assert
            ClassicAssert.IsFalse(addnt, "No hay que añadir");
        }
        [Test]
        public void AddItemOutOfRange()
        {
            //Arrange
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 3);
            //Act
            bool add = board.AddItem(0, 32, 69);
            //Assert
            ClassicAssert.IsFalse(add, "Fuera de Rango");
        }
        [Test]
        public void TryAddItem()
        {
            //Arrange
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 3);
            //Act
            board.AddItem(0, 2, 69);
            bool add = board.AddItem(0, 2, 69);
            //Assert
            ClassicAssert.IsFalse(add, "Ya hay un item");
        }
        [Test]
        public void TryAddIteminfullarray()
        {
            //Arrange
            Board board = new Board(3, 3, "i0i" + "iw0" + "000", 1);
            //Act
            board.AddItem(0, 0, 69);
            //Assert
            Assert.That(() => board.AddItem(0,2,69), Throws.Exception, "hay excepción");
        }
        [Test]
        public void PickItem()
        {
            //Arrange
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 1);
            board.AddItem(0, 2, 69);
            //Act
            int e = board.PickItem(0,2);
            //Assert
            Assert.That(e , Is.EqualTo(69) , "el valor del pickItem no es el mismo que el del item") ;

        }
        [Test]
        public void PickntItem()
        {
            //Arrange
            Board board = new Board(3, 3, "000" + "0w0" + "000", 1);
            
            //Act
            int e = board.PickItem(0, 2);
            //Assert
            Assert.That(e, Is.EqualTo(-1), "el valor del pickItem no es -1 por lo que esta pillando valor");

        }
        [Test]
        public void GetItem()
        {
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 1);
            Item item = new Item();
            item.row = 0;
            item.col = 2;
            item.value = 2;
            board.AddItem(0, 2, 2);
            Assert.That(item, Is.EqualTo(board.GetItem(0)), "no se pudo coger un item existente");
        }
        [Test]
        public void GetntItem()
        {
            Board board = new Board(3, 3, "00i" + "0w0" + "000", 1);


            Assert.That(() => board.GetItem(0), Throws.Exception, "hay excepción");
        }
       
    }
    [TestFixture]
    ///TESTS DE LA CLASE PLAYER
    public class Testplayer
    {
        [Test]
        public void GoalReached() 
        {
            Board board = new Board(3, 3, "g0i" + "0w0" + "000", 1);
            Player player = new Player();
            ClassicAssert.IsTrue(player.GoalReached(board), "Esta en la meta");
        }
        [Test]
        public void GoalntReached()
        {
            Board board = new Board(3, 3, "00i" + "0w0" + "00g", 1);
            Player player = new Player();
            ClassicAssert.IsFalse(player.GoalReached(board), "No esta en la meta");
        }
        [Test]
        public void PickItem()
        {
            Board board = new Board(3, 3, "i0i" + "0w0" + "00g", 1);
            Player player = new Player();
            board.AddItem(0,0,2);
            ClassicAssert.IsTrue(player.PickItem(board), "has cogido el item");
        }
        [Test]
        public void PickntItem()
        {
            Board board = new Board(3, 3, "00i" + "0w0" + "00g", 1);
            Player player = new Player();
            ClassicAssert.IsFalse(player.PickItem(board), "no has cogido el item");
        }
        [Test]
        public void InventoryValue()
        {            
            Board board = new Board(3, 3, "i00" + "0w0" + "00g", 1);
            Player player = new Player();
            board.AddItem(0, 0, 2);
            player.PickItem(board);
           
            Assert.That(player.InventoryValue(board), Is.EqualTo(2), "no cuadra el valor con  el esperado");
        }
        [Test]
        public void SePuedeMover()
        {
            Board board = new Board(3, 3, "i00" + "0w0" + "00g", 1);
            Direction direction = new Direction();
            direction = Direction.North;
            Player player = new Player();
            ClassicAssert.IsFalse(player.CanMoveInDirection(board, direction), "Error: No debería haber muro");
        }
        [Test]
        public void NoSePuedeMover()
        {
            Board board = new Board(3, 3, "0w0" + "0w0" + "00g", 1);
            Direction direction = new Direction();
            direction = Direction.North;
            Player player = new Player();
            ClassicAssert.IsTrue(player.CanMoveInDirection(board, direction), "Error: Debería haber muro");
        }
        [Test]
        public void NoSeHaMovido()
        {
            Board board = new Board(3, 3, "0w0" + "0w0" + "00g", 1);
            Direction direction = new Direction();
            direction = Direction.North;
            Player player = new Player();
            ClassicAssert.IsFalse(player.Move(board, direction), "Error: Se debería de mover");
        }
        [Test]
        public void SeHaMovido()
        {
            Board board = new Board(3, 3, "i00" + "0w0" + "00g", 1);
            Direction direction = new Direction();
            direction = Direction.North;
            Player player = new Player();
            ClassicAssert.IsTrue(player.Move(board, direction), "Error: No Se debería de mover");
        }
    }
}
