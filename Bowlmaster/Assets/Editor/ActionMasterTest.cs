using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private List<int> pinFalls;
	private ActionMaster.Action tidy    = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset   = ActionMaster.Action.Reset;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

	[SetUp]
	public void Setup() {
		pinFalls = new List<int> ();
	}

	[Test]
	public void T00_PassingTest() {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_OneStrikeReturnsEndTurn() {
		pinFalls.Add (10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction (pinFalls));
	}

	[Test]
	public void T02_Bowl8ReturnsTidy() {
		pinFalls.Add (8);
		Assert.AreEqual (tidy, ActionMaster.NextAction (pinFalls));
	}

	[Test]
	public void T03_BowlEndFrameReturnsEndTurn() {
		pinFalls.Add (3);
		pinFalls.Add (3);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T04_Bowl2And8SpareReturnEndTurn() {
		pinFalls.Add (2);
		pinFalls.Add (8);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T05_ThirdPlayInLastFrameReturnsEndGame() {
		for (int i = 1; i <= 12; i++) {
			pinFalls.Add (10);
		}
		Assert.AreEqual (endGame, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T06_StrikeOnPlay1InLastFrameReturnsReset() {
		for (int i = 1; i < 19; i++) {
			pinFalls.Add (0);
		}
		pinFalls.Add (10);
		Assert.AreEqual (reset, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T07_StrikeOnPlay2InLastFrameReturnsReset() {
		for (int i = 1; i < 19; i++) {
			pinFalls.Add (4);
		}
		pinFalls.Add (10);
		pinFalls.Add (10);
		Assert.AreEqual (reset, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T08_NoSpareOnLastFrameReturnEndGame() {
		for (int i = 1; i <= 20; i++) {
			pinFalls.Add (4);
		}
		Assert.AreEqual(endGame, ActionMaster.NextAction (pinFalls));
	}

	[Test]
	public void T09_SpareOnLastFrameReturnsReset() {
		for (int i = 1; i < 19; i++) {
			pinFalls.Add (4);
		}
		pinFalls.Add (2);
		pinFalls.Add (8);
		Assert.AreEqual (reset, ActionMaster.NextAction (pinFalls));
	}

	[Test]
	public void T10_StrikeOnPlay1NoStrikeOnPlay2InLastFrameReturnsTidy() {
		for (int i = 1; i < 19; i++) {
			pinFalls.Add (4);
		}
		pinFalls.Add (10);
		pinFalls.Add (9);
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T11_StrikeOnPlay1ZeroOnPlay2InLastFrameReturnsTidy() {
		for (int i = 1; i < 19; i++) {
			pinFalls.Add (4);
		}
		pinFalls.Add (10);
		pinFalls.Add (0);
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T12_StrikeOnLatterHalfOfFrameIncrementsBowlBy1() {
		pinFalls.Add (0);
		pinFalls.Add (10);
		pinFalls.Add (0);
		Assert.AreEqual (tidy, ActionMaster.NextAction (pinFalls));
	}
}