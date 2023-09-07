import Dispatcher from '../dispatcher';
import ActionTypes from '../constants';
import axios from 'axios';

class ContentActions {

    UpdateContentRating(content) {
        // API cals
        Dispatcher.dispatch({
            actionType: ActionTypes.UPDATE_CONTENT_RATING,
            payload: content
        });
    }

    LoadFirstUnrated() {
        axios.get('http://localhost:5033/api/Contents/first-unrated')
            .then(response => {
                Dispatcher.dispatch({
                    actionType: ActionTypes.LOAD_FIRST_UNRATED,
                    payload: response.data
                });
            })
            .catch(error => {
                console.log(error);
            });

        
    }
}

export default new ContentActions();