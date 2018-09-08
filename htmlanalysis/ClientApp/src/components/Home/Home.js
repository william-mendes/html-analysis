import React, { Component } from 'react';
import Counter from './Counter';


export class Home extends Component {
    displayName = Home.name

    constructor(props) {
        super(props);
        this.state = { url: '', wordsFrequencies: null };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(evt) {

        var url = this.state.url;

        fetch('api/frequencies/read?url=' + url)
        .then(response => response.json())
        .then(data => {
            this.setState({ wordsFrequencies: data.frequencies, loading: false });
        });

        return evt.preventDefault();
    }

    handleChange(evt) {
        const target = evt.target;
        this.setState({ url: target.value });
    }

    renderInputPanel() {
        return (
            <div>
                <h1>Word Counter</h1>
                <p>Single-page application to fetch words from an URL</p>
                <div id="urlInputPanel" >
                    <form>
                        <div className="form-group">
                            <label htmlFor="url">URL</label>
                            <input
                                type="text"
                                className="form-control"
                                id="url"
                                value={this.state.url}
                                onChange={this.handleChange}
                                placeholder="Enter a url to count the contents words"
                            />
                        </div>
                        <button
                            type="submit"
                            onClick={this.handleSubmit}
                            className="btn btn-primary"
                        >
                            Submit
                        </button>
                    </form>
                </div>
            </div>
        );
    }

    renderCounterPanel() {
        return (
            <div>
                {Counter.renderPanel(this.state)}
            </div>
        );
    }

    render() {
        return (
            <div>
                {this.renderInputPanel()}

                <hr />

                {this.state.url !== null && this.state.wordsFrequencies !== null
                    ? this.renderCounterPanel()
                    : null}
            </div>
        );
    }
}