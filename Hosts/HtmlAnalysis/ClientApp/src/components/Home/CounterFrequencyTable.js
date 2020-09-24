import React, { Component } from 'react';

export default class CounterFrequencyTable extends Component {
    displayName = CounterFrequencyTable.name

    static wordFontSize(wordFrequency, index) {
        var fontSize = 6 - ((index/100) * 6)
        return (
            <p style={{ fontSize: fontSize + 'em' }}>{wordFrequency.word} - {wordFrequency.count}</p>
        );
    }

    static renderWordFrequencyTable(wordsFrequencies) {
        if (wordsFrequencies !== null) {
        return (
            <ul>
                {wordsFrequencies
                    .sort((a, b) => a.count - b.count)
                    .reverse()
                    .map((wordFrequency, index) => (
                        <li className="text-center" style={{ listStyle: "none" }} key={index}>
                            {this.wordFontSize(wordFrequency, index)}
                        </li>
                    ))}
            </ul>
            );
        }
    }
}