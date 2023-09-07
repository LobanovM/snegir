import React from "react";

class Content extends React.Component {

    constructor(props) {
        super(props);

        this.imageSrc = "http://localhost:5033/api/Contents/image?contentId=" + this.props.content.id;
    }

    render() {
        return (
            <div>
                <img className="img-fluid rounded" src={this.imageSrc} alt="Content image" />
                <h3>{this.props.content.name}</h3>
            </div>
        );
    }
}
export default Content;