//
//  UIView+Extension.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 05/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import UIKit

extension UIView {
    
    func findViewController() -> UIViewController? {
        if let nextResponder = self.next as? UIViewController {
            return nextResponder
        } else if let nextResponder = self.next as? UIView {
            return nextResponder.findViewController()
        } else {
            return nil
        }
    }
}
