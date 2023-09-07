import React from "react";
import ContentActions from '../actions/contentActions';
import Content from "./content";
import ContentStore from '../stores/contentStore';

class ContentRating extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            content: null
        };

        this._onChange = this._onChange.bind(this);
    }

    _onChange() {
        this.setState({ content: ContentStore.getFirstUnrated() });
    }

    componentDidMount() {
        console.log('componentDidMount');
        ContentStore.addChangeListener(this._onChange);
        ContentActions.LoadFirstUnrated();
    }

    componentWillUnmount() {
        console.log('componentWillUnmount');
        ContentStore.removeChangeListener(this._onChange);
    }

    _updateState(event) {
        let field = event.target.name;
        let value = event.target.value;

        this.state.content[field] = value;
        this.setState({ content: this.state.content });
    }

    _updateContentRating(event) {
        event.preventDefault();
        this.state.content.rating = this.state.content.rating || '0';
        ContentActions.UpdateContentRating(this.state.content);

        this.setState({
            content: {
                name: 'first-unrated',
                rating: 0
            } });
    }

    render() {
        if (this.state.content) {
            return (
                <div>
                    <h3>Content rating</h3>
                    <form onSubmit={this._updateContentRating.bind(this)}>
                        <Content content={this.state.content} />
                        <input type="text" name="rating" value={this.state.content.rating} placeholder="Rating" onChange={this._updateState.bind(this)} />
                        <button type="submit">Save and next</button>
                    </form>
                </div>
            );
        }
        else {
            return (
                <p>Loading...</p>
            );
        }
    }
}
export default ContentRating;