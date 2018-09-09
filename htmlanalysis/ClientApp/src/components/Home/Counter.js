import React, { Component } from 'react';
import FrequencyTable from './CounterFrequencyTable'

export default class Counter extends Component {
    displayName = Counter.name

    static renderPanel(state) {
        let contents = state.loading
            ? <p><em>Loading...</em></p>
            : FrequencyTable.renderWordFrequencyTable(state.wordsFrequencies);

        return (
            <div>
                <h1>Word Frequencies</h1>
                <p>This component demonstrates the top 100 most frequent word on the given url.</p>
                <hr />
                {contents}
            </div>
        );
    }
}