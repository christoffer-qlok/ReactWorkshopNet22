import React, { useState } from 'react';
import GuessForm from './GuessForm';

const Game = () => {
    const [gameId, setGameId] = useState(null);
    const [answer, setAnswer] = useState(null);

    const startNewGame = async () => {
        try {
            const response = await fetch('/api/game', { method: 'POST' });
            const data = await response.json();
            setGameId(data.gameId);
            setAnswer(null);
        } catch (error) {
            console.error('Error: ', error);
        }
    };

    const handleGuess = async (guess) => {
        try {
            const response = await fetch(`/api/guess/${gameId}/${guess}`);
            const data = await response.json();
            setAnswer(data.correct);
        } catch (error) {
            console.error('Error: ', error);
        }
    }

    return (
        <div>
            <h1>Guess the number</h1>
            <button onClick={startNewGame}>New Game</button>
            <GuessForm onGuess={handleGuess} />
            {answer !== null && <p>{answer ? 'Correct guess!' : 'Incorrect :('}</p>}
        </div>
    )
}

export default Game;