class Content extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.content };
    }

    render() {
        return <div>
            <p><b>{this.state.data.name}</b></p>
            <p>ID: {this.state.data.id}</p>
            <p>Rating: {this.state.data.rating}</p>
        </div>;
    }
}

class ContentList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { contents: [] };
    }

    // загрузка данных
    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ contents: data });
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {
        this.loadData();
    }

    render() {

        return <div>
            <h2>Content list</h2>
            <div>
                {
                    this.state.contents.map(function (content) {

                        return <Content key={content.id} content={content} />
                    })
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <ContentList apiUrl="/api/contents" />,
    document.getElementById("content")
);