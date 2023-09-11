import React from "react";

class Rating extends React.Component {

    constructor(props) {
        super(props);

        this.currentRating = this.props.value;
    }

    _getRating(rating) {
        return {
            rating1: rating >= 1,
            rating2: rating >= 2,
            rating3: rating >= 3,
            rating4: rating >= 4,
            rating5: rating >= 5
        };
    }

    _updateRating(rating) {
        this.currentRating = (rating === this.currentRating) ? 0 : rating;
        this.props.onChange(this.currentRating);
    }

    render() {
        return (
            <div className="btn-group" role="group" aria-label="Basic checkbox toggle button group">
                <input type="checkbox" className="btn-check" name="rating1" id="btnradio1" autoComplete="off" wfd-id="id1" checked={this._getRating(this.props.value).rating1} onChange={() => this._updateRating(1)} />
                <label className="btn btn-outline-secondary" htmlFor="btnradio1">&#9733;</label>

                <input type="checkbox" className="btn-check" name="rating2" id="btnradio2" autoComplete="off" wfd-id="id2" checked={this._getRating(this.props.value).rating2} onChange={() => this._updateRating(2)} />
                <label className="btn btn-outline-secondary" htmlFor="btnradio2">&#9733;</label>

                <input type="checkbox" className="btn-check" name="rating3" id="btnradio3" autoComplete="off" wfd-id="id3" checked={this._getRating(this.props.value).rating3} onChange={() => this._updateRating(3)} />
                <label className="btn btn-outline-secondary" htmlFor="btnradio3">&#9733;</label>

                <input type="checkbox" className="btn-check" name="rating4" id="btnradio4" autoComplete="off" wfd-id="id4" checked={this._getRating(this.props.value).rating4} onChange={() => this._updateRating(4)} />
                <label className="btn btn-outline-secondary" htmlFor="btnradio4">&#9733;</label>

                <input type="checkbox" className="btn-check" name="rating5" id="btnradio5" autoComplete="off" wfd-id="id5" checked={this._getRating(this.props.value).rating5} onChange={() => this._updateRating(5)} />
                <label className="btn btn-outline-secondary" htmlFor="btnradio5">&#9733;</label>
            </div>
        );
    }
}
export default Rating;