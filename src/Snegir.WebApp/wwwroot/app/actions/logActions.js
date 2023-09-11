import Dispatcher from '../dispatcher';
import ActionTypes from '../constants';

class LogActions {

    ClearErrors() {
        Dispatcher.dispatch({
            actionType: ActionTypes.LOG_CLEAR_ERRORS,
            payload: null
        });
    }
}

export default new LogActions();