import React from "react";
import ContentActions from '../actions/contentActions';
import Content from "./content";
import Rating from "./rating";
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
        ContentStore.addChangeListener(this._onChange);
        ContentActions.LoadFirstUnrated();
    }

    componentWillUnmount() {
        ContentStore.removeChangeListener(this._onChange);
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
        console.log(rating);
        this.state.content.rating = rating;
        this.setState({ content: this.state.content });
    }

    render() {
        if (this.state.content) {
            return (
                <div className="container py-4 px-3 mx-auto">
                    <form onSubmit={this._updateContentRating.bind(this)}>
                        <Content content={this.state.content} />
                        <Rating value={this.state.content.rating} onChange={this._updateRating.bind(this)} />
                        <div>
                            <button className="btn btn-primary" type="submit" disabled={ this.state.content.rating === 0 }>Save and next</button>
                        </div>
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