import React from "react";

class Content extends React.Component {

    render() {
        return (
            <div>
                <h3>Content</h3>
                <p>{this.props.content.name}</p>
            </div>
        );
    }
}
export default Content;