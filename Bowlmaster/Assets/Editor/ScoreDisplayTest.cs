using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00_PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_Bowl1 () {
		int[] rolls = { 1 };
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T02_Bowl12() {
		int[] rolls = { 1, 2 };
		string rollsString = "12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));

	}

	[Test]
	public void T03_Bowl123() {
		int[] rolls = { 1, 2, 3 };
		string rollsString = "123";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));

	}

	[Test]
	public void T04_Bowl1234() {
		int[] rolls = { 1, 2, 3, 4 };
		string rollsString = "1234";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));

	}

	[Test]
	public void T05_BowlStrike() {
		int[] rolls = { 10 };
		string rollsString = " X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T06_Bowl28() {
		int[] rolls = {2, 8};
		string rollsString = "2/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T07_Bowl1234Strike28() {
		int[] rolls = {1,2, 3,4, 10, 2,8};
		string rollsString = "1234 X2/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T08_Bowl1234Turkey() {
		int[] rolls = {1,2, 3,4, 10, 10, 10};
		string rollsString = "1234 X X X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T09_AllZeros() {
		int[] rolls = {0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0};
		string rollsString = "--------------------";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T10_Bowl10200340() {
		int[] rolls = {1,0,2,0,0,3,4,0};
		string rollsString = "1-2--34-";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T11_Bowl0Spare() {
		int[] rolls = { 0,10 };
		string rollsString = "-/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T12_BowlStrike0Spare() {
		int[] rolls = { 10, 0,10 };
		string rollsString = " X-/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test] 
	public void T13_SpareOnLastFrameGivesExtraBowl() {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 8, 4 };
		string rollsString = "11"+"11"+"11"+"11"+"11"+"11"+"11"+"11"+"11"+"2/"+"4";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test] 
	public void T14_StrikeOnLastFrameGivesTwoExtraBowls() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,2,3  };
		string rollsString = "11"+"11"+"11"+"11"+"11"+"11"+"11"+"11"+"11"+ "X23";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test] 
	public void T15_TwoStrikesOnLastFrameGivesExtraBowl() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,3  };
		string rollsString = "11"+"11"+"11"+"11"+"11"+"11"+"11"+"11"+"11"+ "XX3";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test] 
	public void T16_PerfectGame() {
		int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
		string rollsString = " X" + " X" + " X" + " X" + " X" + " X" + " X" + " X" + " X" + "XXX";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test] 
	public void T17_StrikeSpareOnLAstFrame() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,7,3  };
		string rollsString = "11"+"11"+"11"+"11"+"11"+"11"+"11"+"11"+"11"+ "X7/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	// http://slocums.homestead.com/gamescore.html
	[Test]
	[Category ("Verification")]
	public void TG02GoldenCopyA () {
		int[] rolls = { 10, 7,3, 9,0, 10, 0,8, 8,2, 0,6, 10, 10, 10,8,1};
		string rollsString = " X7/9- X-88/-6 X XX81";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}
	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyC1of3 () {
		int[] rolls = { 7,2, 10, 10, 10, 10, 7,3, 10, 10, 9,1, 10,10,9};
		string rollsString = "72 X X X X7/ X X9/XX9";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	// http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
	[Category ("Verification")]
	[Test]
	public void TG03GoldenCopyC2of3 () {
		int[] rolls = { 10, 10, 10, 10, 9,0, 10, 10, 10, 10, 10,9,1};
		string rollsString = " X X X X9- X X X XX9/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}
}
