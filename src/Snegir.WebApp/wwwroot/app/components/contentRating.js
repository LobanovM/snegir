import React from "react";
import ContentActions from '../actions/contentActions';
import LogActions from '../actions/logActions';
import Content from "./content";
import Rating from "./rating";
import ContentStore from '../stores/contentStore';
import LogStore from '../stores/logStore';

class ContentRating extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            content: undefined,
            error: null
        };

        this._onChange = this._onChange.bind(this);
        this._onChangeFirstUnrated = this._onChangeFirstUnrated.bind(this);
        this._onLogChange = this._onLogChange.bind(this);
    }

    _onChange() {
        ContentActions.LoadFirstUnrated();
    }

    _onLogChange() {
        this.setState({ error: LogStore.getLastError() });
    }

    _onChangeFirstUnrated() {
        let content = ContentStore.getFirstUnrated();
        this.setState({ content: content });
    }

    componentDidMount() {
        LogStore.addChangeListener(this._onLogChange);
        ContentStore.addChangeListener(this._onChange);
        ContentStore.addChangeFirstUnratedListener(this._onChangeFirstUnrated);
        ContentActions.LoadFirstUnrated();
    }

    componentWillUnmount() {
        LogStore.removeChangeListener(this._onLogChange);
        ContentStore.removeChangeListener(this._onChange);
        ContentStore.removeChangeFirstUnratedListener(this._onChangeFirstUnrated);
    }

    /*_updateState(event) {
        let field = event.target.name;
        let value = event.target.value;

        this.state.content[field] = value;
        this.setState({ content: this.state.content });
    }*/

    _updateContentRating(event) {
        event.preventDefault();

        if (this.state.content.rating > 0) {
            ContentActions.UpdateContentRating(this.state.content);
        }

    }

    _updateRating(rating) {
        this.state.content.rating = rating;
        this.setState({ content: this.state.content });
    }

    _errorClsoe() {
        LogActions.ClearErrors();
    }

    render() {
        let error = (this.state.error)
            ? <div className="alert alert-danger alert-dismissible fade show" role="alert">{this.state.error}
                <button type="button" className="close" data-dismiss="alert" aria-label="Close" onClick={this._errorClsoe.bind(this)}>
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
            : null;

        if (this.state.content) {

            let sourceButton = (this.state.content.source)
                ? <a className="btn btn-secondary" href={this.state.content.source} target="_blank" >Source</a>
                : <button className="btn btn-secondary" disabled>Source</button>;

            return (
                <div className="container py-3 mx-auto">
                    {error}
                    <form onSubmit={this._updateContentRating.bind(this)}>
                        <div className="p-3 text-light-emphasis bg-light-subtle border border-light-subtle rounded-3">
                            <Content content={this.state.content} />
                            <div className="d-inline">
                                <Rating value={this.state.content.rating} onChange={this._updateRating.bind(this)} />
                            </div>
                            <div className="d-inline p-2">
                                {sourceButton}
                            </div>
                        </div>
                        <div className="py-2 px-1 text-center">
                            <button className="btn btn-primary" type="submit" disabled={ this.state.content.rating === 0 }>Save and next</button>
                        </div>
                    </form>
                </div>
            );
        }
        else if (this.state.content === undefined) {
            return (
                <div className="d-flex justify-content-center">
                    <div className="spinner-border m-5" role="status">
                        <span className="visually-hidden">Loading...</span>
                    </div>
                </div>
            );
        }
        else {
            return (
                <div className="container py-3 mx-auto">
                    <div className="alert alert-success" role="alert">No new content.</div>
                </div>
            );
        }
    }
}
export default ContentRating;