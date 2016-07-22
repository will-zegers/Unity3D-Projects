using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster actionMaster;
	private ActionMaster.Action tidy    = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset   = ActionMaster.Action.Reset;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

	[SetUp]
	public void Setup() {
		actionMaster = new ActionMaster ();
	}

	[Test]
	public void T00_PassingTest() {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_OneStrikeReturnsEndTurn() {
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02_Bowl8ReturnsTidy() {
		Assert.AreEqual (tidy, actionMaster.Bowl (8));
	}

	[Test]
	public void T03_BowlEndFrameReturnsEndTurn() {
		actionMaster.Bowl (3);
		Assert.AreEqual (endTurn, actionMaster.Bowl (3));
	}

	[Test]
	public void T04_Bowl2And8SpareReturnEndTurn() {
		Assert.AreEqual (tidy, actionMaster.Bowl (2));
		Assert.AreEqual (endTurn, actionMaster.Bowl (8));
	}

	[Test]
	public void T05_ThirdPlayInLastFrameReturnsEndGame() {
		for (int i = 1; i < 21; i++) {
			actionMaster.Bowl (0);
		}
		Assert.AreEqual (endGame, actionMaster.Bowl (0));
	}

	[Test]
	public void T06_NoStrikeLastFrameReturnsEndGame() {
		for (int i = 1; i < 18; i++) {
			actionMaster.Bowl (10);
		}
		actionMaster.Bowl (0);
		Assert.AreEqual (endGame, actionMaster.Bowl (0));
	}

	[Test]
	public void T07_SpareOnLastFrameReturnsReset() {
		for (int i = 1; i < 19; i++) {
			actionMaster.Bowl(0);
		}
		actionMaster.Bowl (2);
		Assert.AreEqual(reset, actionMaster.Bowl(8));
	}

	[Test]
	public void T08_StrikeOnLastFrameReturnsReset() {
		for (int i = 0; i < 19; i++) {
			actionMaster.Bowl (0);
		}
		Assert.AreEqual (reset, actionMaster.Bowl (10));
	}

	[Test]
	public void T09_StrikeOnPlay1NoStrikeOnPlay2LastFrameReturnsReset() {
		for (int i = 1; i < 19; i++) {
			actionMaster.Bowl (0);
		}
		actionMaster.Bowl (10);
		Assert.AreEqual (reset, actionMaster.Bowl (0));
	}
}