import React from "react";

class Content extends React.Component {

    constructor(props) {
        super(props);

        this.imageSrc = "http://localhost:5033/api/Contents/image?contentId=" + this.props.content.id;
    }

    render() {
        return (
            <div>
                <h3>Content</h3>
                <p>{this.props.content.name}</p>
                <img src={this.imageSrc} alt="Content image" />
            </div>
        );
    }
}
export default Content;