import React from "react";

class Content extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <img className="img-fluid rounded" src={"http://localhost:5033/api/Contents/image?contentId=" + this.props.content.id} alt="Content image" />
                <h3>{this.props.content.name}</h3>
            </div>
        );
    }
}
export default Content;