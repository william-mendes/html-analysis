import React, { Component } from 'react';

export default class ReportFrequencyTable extends Component {
    displayName = ReportFrequencyTable.name

    static renderWordFrequencyTable(wordsFrequencies) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Word</th>
                        <th>Frequency</th>
                    </tr>
                </thead>
                <tbody>
                    {wordsFrequencies
                        .sort((a, b) => a.count < b.count)
                        .map(wordFrequency =>
                        <tr key={wordFrequency.word}>
                            <td>{wordFrequency.word}</td>
                            <td>{wordFrequency.count}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}