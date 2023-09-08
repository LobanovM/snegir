import Dispatcher from '../dispatcher';
import ActionTypes from '../constants';
import axios from 'axios';

class ContentActions {

    UpdateContentRating(content) {
        axios.post('http://localhost:5033/api/Contents/update-rating', {
                contentId: content.id,
                rating: content.rating
            })
            .then(response => {
                Dispatcher.dispatch({
                    actionType: ActionTypes.UPDATE_CONTENT_RATING,
                    payload: content
                });
            })
            .catch(error => {
                Dispatcher.dispatch({
                    actionType: ActionTypes.LOG_ERROR,
                    payload: error.message
                });
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
                Dispatcher.dispatch({
                    actionType: ActionTypes.LOG_ERROR,
                    payload: error.message
                });
            });

        
    }
}

export default new ContentActions();